-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Апр 07 2020 г., 03:17
-- Версия сервера: 5.7.24
-- Версия PHP: 7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `ats`
--
CREATE DATABASE IF NOT EXISTS `ats` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ats`;

DELIMITER $$
--
-- Процедуры
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `addEmployeeToTeam` (IN `empID` INT(11), IN `teamID` INT(11))  NO SQL
BEGIN
	INSERT INTO TeamMembers(EmployeeId, TeamId)
    VALUES (empID, teamID);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `addJobTask` (IN `teamID` INT, IN `jobID` INT, IN `emp_first_tasks_list` VARCHAR(64), IN `emp_second_tasks_list` VARCHAR(64), IN `parallel_work` BIT(1), IN `is_on_call` BIT(1), IN `required_tasks_list` VARCHAR(64), OUT `out_total_duration` INT)  BEGIN
	SET @profit_multiplier = 3;
    SET @job_duration = null;
    
    # Check if parallel working
    IF parallel_work = 1 THEN
        SET @job_duration = (SELECT GREATEST(@emp_hours_first,@emp_hours_second));
    END IF;
    
    
    # Check if on call
    IF is_on_call = 1 THEN
        SET @team_tasks_list = CONCAT(emp_first_tasks_list, emp_second_tasks_list);
        IF (@team_tasks_list LIKE CONCAT('%', @required_tasks_list, '%')) THEN   		# Not Sure how to check that Team Skills have all the Required Skills
			SET @profit_multiplier = 4;
		ELSE # Calculate if no matchuing skills
			SET @job_duration = (SELECT SUM(Duration) FROM Tasks WHERE id in (select find_in_set(id, required_tasks_list))) / 60;
        END IF;
	END IF;
    
    
	# Details for First Employee
	SET @emp_id_first = (select EmployeeID from TeamMembers where TeamId = teamID order by id limit 1);
    SET @emp_name_first = (select CONCAT(FirstName, ' ', LastName) from Employees Where id = @emp_id_first);
    SET @emp_hours_first = 
		(select sum(Duration) / 60 from Tasks Where id in 
			(select find_in_set(id, emp_first_tasks_list)));
	SET @emp_rate_first = (select HourlyRate from Employees WHERE id = @emp_id_first);
    SET @emp_cost_first = IF(@job_duration IS NULL, @emp_hours_first, @job_duration) * @emp_rate_first;
    SET @emp_revenue_first = @emp_cost_first * @profit_multiplier;
    
    
    # Details for Second Employee
	SET @emp_id_second = (select EmployeeID from TeamMembers where TeamId = teamID order by id desc limit 1);
    SET @emp_name_second = (select CONCAT(FirstName, ' ', LastName) from Employees Where id = @emp_id_second);
    SET @emp_hours_second = 
		(select sum(Duration) / 60 from Tasks Where id in 
			(select find_in_set(id, emp_second_tasks_list)));
	SET @emp_rate_second = (select HourlyRate from Employees WHERE id = @emp_id_second);
    SET @emp_cost_second = IF(@job_duration IS NULL, @emp_hours_second, @job_duration) * @emp_rate_second;
    SET @emp_revenue_second = @emp_cost_second * @profit_multiplier;
    
    
    # Totals
    SET @total_cost = @emp_cost_first + @emp_cost_second;
    SET @total_revenue = @emp_revenue_first + @emp_revenue_second;
    SET @total_billable = @total_revenue * 1.15;


	# Get the total duration and return it
    SET out_total_duration = IF(@job_duration IS NULL, (@emp_hours_first + @emp_hours_second)*60, @job_duration*60);
    
    INSERT INTO JobTasks VALUES(taskID, jobID, @total_cost, @total_billable);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `createEmployee` (IN `FirstName_param` VARCHAR(255), IN `LastName_param` VARCHAR(255), IN `Sin_param` VARCHAR(255), IN `HourlyRate_param` INT(10), IN `CreatedAt_param` DATE, OUT `Id_out` INT(10))  BEGIN

    INSERT INTO Employees(FirstName, LastName, Sin, HourlyRate, CreatedAt)
    VALUES(FirstName_param,LastName_param,Sin_param, HourlyRate_param,CreatedAt_param);

    SET Id_out = LAST_INSERT_ID();

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `createEmployeeSkills` (IN `TaskId_param` INT, IN `EmployeeId_param` INT)  BEGIN
	INSERT INTO EmployeessTasks(EmployeeId, TaskId)
    VALUES(EmployeeId_param, TaskId_param);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `createJob` (OUT `idOut` INT, IN `teamId` INT, IN `description` VARCHAR(255), IN `clientName` VARCHAR(50), IN `start` DATETIME, IN `emp_first_tasks_list` VARCHAR(64), IN `emp_second_tasks_list` VARCHAR(64), IN `parallel_work` BIT(1), IN `is_on_call` BIT(1), IN `required_tasks_list` VARCHAR(64))  BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;  -- rollback any changes made in the transaction
        RESIGNAL;  -- raise again the sql exception to the caller
    END;
	
    # Get the job task duration and calculate job end time
	CALL getJobTaskDurationProc(emp_first_tasks_list,emp_second_tasks_list,parallel_work,is_on_call,required_tasks_list, @job_duration);
    SET @job_end_time = DATE_ADD(start, INTERVAL @job_duration MINUTE);
    
    SET @on_call = (select IsOnCall from Teams where id = teamId);
    
    # Must not be able to double book any teams
    IF (SELECT COUNT(*) FROM Jobs WHERE TeamId = teamId) > 0 THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Can not double book teams';
    END IF;
    
    # Check if its weekends and team is not on call
    IF (DAYOFWEEK(start) = 1 OR DAYOFWEEK(start) = 7 AND @on_call = 0) OR 
		(DAYOFWEEK(@job_end_time) = 1 OR DAYOFWEEK(@job_end_time) = 7 AND @on_call = 0)
    THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Can not create job during the weekends';
    END IF;
    
    # Check time 8am - 5pm and team is on call
    IF (HOUR(start) < 7 OR HOUR(start) > 17 AND @on_call = 0) OR
		(HOUR(@job_end_time) < 7 OR HOUR(@job_end_time) > 17 AND @on_call = 0)
    THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Can not create job during off business hours';
    END IF;
    
	#  I cannot create jobs in the past
    IF (TIMESTAMP(start) < NOW()) THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Can not create job in the past';
    END IF;
    
    # No errors or br violations insert job
	START TRANSACTION;
        
	INSERT INTO Jobs(TeamId, Description, ClientName, Start, End)
	VALUES(teamId, description, clientName, start, end);
		
	SET idOut = LAST_INSERT_ID();
	COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `createTask` (IN `name` VARCHAR(50), IN `description` VARCHAR(255), IN `duration` INT(11), OUT `idOut` INT(11))  BEGIN
	INSERT INTO Tasks(Name, Description, Duration)
    VALUES(name, description, duration);
    
    SET idOut = LAST_INSERT_ID();
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `createTeam` (IN `onCall` BIT(1), IN `name` VARCHAR(50), OUT `idOut` INT(11), IN `memberOne` INT(11), IN `memberTwo` INT(11))  NO SQL
BEGIN
	INSERT INTO Teams(Name, IsOnCall)
    VALUES(name, onCall);
    
    SET idOut = LAST_INSERT_ID();
    
    INSERT INTO TeamMembers(EmployeeId, TeamId)
    VALUES (memberOne, idOut);
    
    INSERT INTO TeamMembers(EmployeeId, TeamId)
    VALUES (memberTwo, idOut);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteEmployee` (IN `Id_param` INT)  BEGIN
    UPDATE Employees SET Employees.DeletedAt = NOW() WHERE Employees.Id = 		Id_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteTasksOfEmployee` (IN `EmployeeId_param` INT)  BEGIN
	DELETE FROM EmployeessTasks WHERE EmployeessTasks.EmployeeId = EmployeeId_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteTeams` (IN `Id_param` INT)  BEGIN
    UPDATE Teams SET Teams.DeletedAt = NOW() WHERE Teams.Id = 		Id_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllSkills` ()  BEGIN
	SELECT Id, Name FROM `Tasks`;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getEmployee` (IN `Id_param` INT(10))  BEGIN
    SELECT `Employees`.Id as EmployeeId, FirstName, LastName, SIN, HourlyRate, `Employees`.CreatedAt, `Employees`.UpdatedAt, `Teams`.`Id` as TeamsId, `Teams`.Name as TeamsName FROM `Employees` LEFT JOIN `TeamMembers` ON `Employees`.`Id` = `TeamMembers`.`EmployeeId` LEFT JOIN `Teams` ON `TeamMembers`.`TeamId` = `Teams`.`Id` WHERE `Employees`.`Id` = Id_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getEmployees` (IN `Id_param` INT(10))  BEGIN
        SELECT Id, FirstName, LastName, Employees.DeletedAt, TeamMembers.TeamId FROM `Employees` LEFT OUTER JOIN TeamMembers ON Employees.Id = TeamMembers.EmployeeId WHERE Id_param IS NULL;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getEmployeeSkills` (IN `Id_param` INT)  BEGIN
SELECT Tasks.Id, Name FROM `EmployeessTasks` INNER JOIN `Tasks` ON `EmployeessTasks`.`TaskId` = `Tasks`.`Id` INNER JOIN Employees ON Employees.Id = EmployeessTasks.EmployeeId WHERE Employees.id = Id_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getJobTaskDuration` (IN `emp_first_tasks_list` VARCHAR(64), IN `emp_second_tasks_list` VARCHAR(64), IN `parallel_work` BIT(1), IN `is_on_call` BIT(1), IN `required_tasks_list` VARCHAR(64), OUT `job_duration` INT)  BEGIN
    SET job_duration = null;
    
	SET @emp_hours_first = 
		(select sum(Duration) from Tasks Where id in 
			(select find_in_set(id, emp_first_tasks_list)));
    
    SET @emp_hours_second = 
		(select sum(Duration) from Tasks Where id in 
			(select find_in_set(id, emp_second_tasks_list)));
	
    
	# Check if parallel working
    IF parallel_work = 1 THEN
        SET @job_duration = (SELECT GREATEST(@emp_hours_first,@emp_hours_second));
    END IF;
    
    
    # Check if on call tuened off now
--     IF is_on_call = 1 THEN
--         SET @team_tasks_list = CONCAT(emp_first_tasks_list, emp_second_tasks_list);
--         IF (@team_tasks_list LIKE CONCAT('%', @required_tasks_list, '%')) THEN   		# Not Sure how to check that Team Skills have all the Required Skills
-- 			SET @profit_multiplier = 4;
-- 		ELSE # Calculate if no matchuing skills
-- 			SET @job_duration = (SELECT SUM(Duration) FROM Tasks WHERE id in (select find_in_set(id, required_tasks_list))) / 60;
--         END IF;
-- 	END IF;
    


	# Get the total duration and return it
    SET job_duration = IF(@job_duration IS NULL, (@emp_hours_first + @emp_hours_second), @job_duration);
    
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getTeam` (IN `Id_param` INT)  BEGIN
    	SELECT DISTINCT Teams.Id, Teams.Name, Teams.DeletedAt, Jobs.TeamId, Jobs.Description, Jobs.Start, Jobs.End FROM Teams LEFT OUTER JOIN Jobs ON Teams.Id = Jobs.TeamId WHERE Teams.Id = Id_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getTeamEmployees` (IN `Id_team_param` INT)  BEGIN
	SELECT Employees.Id, Employees.FirstName, Employees.LastName FROM Teams INNER JOIN TeamMembers ON Teams.Id = TeamMembers.TeamId INNER JOIN Employees ON TeamMembers.EmployeeId = Employees.Id WHERE Teams.Id = Id_team_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getTeams` ()  BEGIN
	SELECT DISTINCT Teams.Id, Teams.Name, Teams.DeletedAt, Jobs.TeamId FROM Teams LEFT OUTER JOIN Jobs ON Teams.Id = Jobs.TeamId;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `listTasks` ()  BEGIN SELECT * FROM Tasks; END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `searchEmployees` (IN `SearchValue_param` VARCHAR(50))  BEGIN
	SELECT Id, FirstName, LastName, Employees.DeletedAt FROM `Employees` WHERE (LastName = SearchValue_param) OR (Employees.SIN = SearchValue_param);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `showTask` (IN `taskId` INT)  BEGIN
SELECT * FROM Tasks Where id = taskId;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CalculateTotals` (IN `taskId_in` INT, IN `teamId_in` INT)  BEGIN
	SET @profit_multiplier = 3;
    
	# Details for First Employee
	SET @emp_id_first = (select EmployeeId from TeamMembers where TeamId = teamId_in order by EmployeeId limit 1);
    SET @emp_hours_first = (select sum(Duration) / 60 from Tasks Where Id = taskId_in);
	SET @emp_rate_first = (select HourlyRate from Employees WHERE Id = @emp_id_first);
    
    # Details for Second Employee
	SET @emp_id_second = (select EmployeeId from TeamMembers where TeamId = teamID order by EmployeeId desc limit 1);
    SET @emp_hours_second = (select sum(Duration) / 60 from Tasks Where Id = taskId_in);
	SET @emp_rate_second = (select HourlyRate from Employees WHERE Id = @emp_id_second);
    
    -- NOTE: Business RUles for Calculation such as Parallel Work and On Call Team with no matching skills are not working right now add them later
	# Check if parallel working
--     IF is_parallel = 1 THEN
--         SET @job_duration = (SELECT GREATEST(@emp_hours_first,@emp_hours_second));
--     END IF;
    
    # Check if on call -- UPDATE IT LATER
-- 	SET @is_on_call = (SELECT IsOnCall FROM Teams WHERE Id = teamId_in);
--     IF @is_on_call = 1 THEN 
-- 		SET @profit_multiplier = 4;
-- 	END IF;
    
    # Employees Totals
    SET @emp_cost_first = IF(@job_duration IS NULL, @emp_hours_first, @job_duration) * @emp_rate_first;
    SET @emp_revenue_first = @emp_cost_first * @profit_multiplier;
    
    SET @emp_cost_second = IF(@job_duration IS NULL, @emp_hours_second, @job_duration) * @emp_rate_second;
    SET @emp_revenue_second = @emp_cost_second * @profit_multiplier;
    
    # Totals
    SET @total_cost = @emp_cost_first + @emp_cost_second;
    SET @total_revenue = @emp_revenue_first + @emp_revenue_second;
    SET @total_billable = @total_revenue * 1.15;
    
    SELECT @total_cost as JobTaskCost, @total_revenue as JobTaskRevenue, @total_billable as TotalBillable;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_currentDateCountJobs` ()  SELECT COUNT(*) as jobsNumber FROM Jobs WHERE Jobs.End >= NOW()$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteJob` (IN `job_id` INT)  begin
	delete from JobTasks where JobId = job_id;
    delete from Jobs where Id = job_id;
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteTask` (IN `task_id` INT)  begin
	delete from Tasks where id = task_id;
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetEmployeeTasks` (IN `in_employeeId` INT)  begin
	select TaskId from EmployeessTasks Where EmployeeId = in_employeeId;
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetJobDetails` (IN `job_id` INT)  begin
	select * from Jobs where id = job_id;
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetJobTasks` (IN `job_id_in` INT)  begin
	select * from JobTasks WHERE JobId = job_id_in;
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getOnCallTeam` ()  BEGIN
SELECT Employees.Id, Employees.FirstName, Employees.LastName, Teams.Name FROM Teams INNER JOIN TeamMembers ON Teams.Id = TeamMembers.TeamId INNER JOIN Employees ON TeamMembers.EmployeeId = Employees.Id WHERE Teams.IsOnCall = 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getRevenueForMonth` (IN `Id_year` INT(10), IN `Id_month` INT(10))  SELECT SUM(JobTasks.OperatingCost) as cost, SUM(JobTasks.OperatingRevenue) as revenue FROM Jobs INNER JOIN JobTasks ON Jobs.Id = JobTasks.JobId
   WHERE MONTH(Jobs.Start) = Id_month AND YEAR(Jobs.Start) = Id_year$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetTeam` (IN `team_id_in` INT)  BEGIN
SELECT * FROM Teams WHERE Id = team_id_in;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetTeamMembers` (IN `in_teamId` INT)  begin
	select EmployeeId from TeamMembers Where TeamId = in_teamId;
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetTeams` ()  BEGIN
select * from Teams where IsDeleted = 0;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetTeamsWithMatchingSkills` (IN `required_tasks_list` VARCHAR(64))  BEGIN
	SET @teamsMatchingSkills = (
    select count(Teams.Name) from Teams where Id in (
		select TeamMembers.TeamId from TeamMembers 
        where TeamMembers.EmployeeId in (
			select EmployeeId from EmployeessTasks where TaskId in (select find_in_set(id, required_tasks_list)
		))
		group by TeamId
        )
        
        );
	
	IF @teamsMatchingSkills = 0 THEN
		SELECT * FROM Teams WHERE IsOnCall = 1
        AND Teams.Id NOT IN (SELECT Jobs.TeamId FROM Jobs);
    END IF;
    
    IF @teamsMatchingSkills > 0 THEN
		select * from Teams where Id in(
		select TeamMembers.TeamId from TeamMembers Where EmployeeId in (
		select EmployeeId from EmployeessTasks WHere TaskId = taskIdToMatch)
		group by TeamId)
        AND Id NOT IN (SELECT Jobs.TeamId FROM Jobs);
    END IF;
    
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertJob` (OUT `idOut` INT, IN `teamId` INT, IN `description` VARCHAR(255), IN `clientName` VARCHAR(50), IN `start` DATETIME, IN `end` DATETIME)  BEGIN
	INSERT INTO Jobs(TeamId, Description, ClientName, Start, End)
	VALUES(teamId, description, clientName, start, end);
		
	SET idOut = LAST_INSERT_ID();
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertJobTask` (IN `taskId` INT, IN `jobId` INT, IN `cost` DECIMAL, IN `revenue` DECIMAL)  BEGIN
	INSERT INTO JobTasks
	VALUES(taskId, jobId, cost, revenue);
		
	
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ShowJob` (IN `job_id_in` INT)  begin
	SELECT * FROM Jobs WHERE id = job_id_in;

end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateEmployee` (IN `FirstName_param` VARCHAR(255), IN `LastName_param` VARCHAR(255), IN `Sin_param` VARCHAR(255), IN `HourlyRate_param` VARCHAR(255), IN `Id_param` INT)  BEGIN
    UPDATE Employees SET FirstName = FirstName_param, LastName = LastName_param, SIN = Sin_param, HourlyRate = HourlyRate_param, UpdatedAt = NOW() WHERE Employees.Id = Id_param;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateTask` (IN `Id_param` INT, IN `Name_param` VARCHAR(255), IN `Description_param` VARCHAR(255), IN `Duration_param` INT)  BEGIN
    UPDATE Tasks SET  Tasks.Name= Name_param, Tasks.Description = Description_param, Tasks.Duration = Duration_param, Tasks.UpdatedAt = NOW() WHERE Tasks.Id = Id_param;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `employees`
--

CREATE TABLE `employees` (
  `Id` int(11) NOT NULL,
  `FirstName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `LastName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `SIN` varchar(11) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `HourlyRate` decimal(13,2) NOT NULL,
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0',
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  `DeletedAt` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `employees`
--

INSERT INTO `employees` (`Id`, `FirstName`, `LastName`, `SIN`, `HourlyRate`, `IsDeleted`, `CreatedAt`, `UpdatedAt`, `DeletedAt`) VALUES
(32, 'NOT IN TEAM BUT DELETED', 'NOT IN TEAM BUT DELETED', '797987', '12.00', b'0', '2020-03-31 00:00:00', NULL, '2020-03-31 14:08:37'),
(33, 'teammember1', 'teammember1', '797987', '12.00', b'0', '2020-03-31 00:00:00', NULL, '2020-03-31 14:13:18'),
(34, 'teammember2', 'teammember2', '797987', '12.00', b'0', '2020-03-31 00:00:00', NULL, '2020-03-31 14:13:29'),
(35, 'NOT DELETED EMP', 'NOT DELETED EMP', '797987', '12.00', b'0', '2020-03-31 00:00:00', NULL, NULL),
(36, 'Nikita', 'Testemployee', '123123123', '12.00', b'0', '2020-04-05 00:00:00', NULL, NULL),
(37, 'Mike', 'Testinserr', '123123123', '12.00', b'0', '2020-04-05 00:00:00', NULL, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `employeesstasks`
--

CREATE TABLE `employeesstasks` (
  `EmployeeId` int(11) NOT NULL DEFAULT '0',
  `TaskId` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `employeesstasks`
--

INSERT INTO `employeesstasks` (`EmployeeId`, `TaskId`) VALUES
(32, 1),
(32, 2),
(33, 1),
(34, 1),
(34, 2),
(35, 1),
(35, 2),
(36, 2),
(37, 3);

-- --------------------------------------------------------

--
-- Структура таблицы `jobs`
--

CREATE TABLE `jobs` (
  `Id` int(11) NOT NULL,
  `TeamId` int(11) DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `ClientName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Start` datetime DEFAULT NULL,
  `End` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `jobs`
--

INSERT INTO `jobs` (`Id`, `TeamId`, `Description`, `ClientName`, `Start`, `End`) VALUES
(2, 8, 'nhhbhjbhjb', 'jkjnkjnkjn', '2020-03-24 02:34:22', '2020-03-24 03:04:22'),
(3, 10, 'Test Job DEscription', 'Niktia', '2020-03-31 20:30:58', '2020-03-31 22:30:58'),
(4, 10, 'JKASNDkjansdk', 'askdjnaskdn', '2020-03-31 20:46:04', '2020-03-31 21:16:04'),
(5, 10, 'JKASNDkjansdk', 'askdjnaskdn', '2020-03-31 20:46:04', '2020-03-31 21:16:04'),
(6, 10, 'JKASNDkjansdk', 'askdjnaskdn', '2020-03-31 20:46:04', '2020-03-31 21:16:04'),
(7, 10, 'asjkdnaskjdn', 'dsakjdnkasjnd', '2020-03-31 20:49:58', '2020-03-31 21:49:58'),
(8, 10, 'asjkdnaskjdn', 'dsakjdnkasjnd', '2020-01-30 20:49:58', '2020-01-30 21:49:58'),
(9, 2, 'asjkdnaskjdn', 'dsakjdnkasjnd', '2020-04-29 20:49:58', '2020-04-30 21:49:58'),
(10, 11, 'asa', 'sass', '2020-04-06 01:35:40', '2020-04-06 02:05:40'),
(11, 10, 'asasasas', 'asasa', '2020-04-06 01:37:45', '2020-04-06 02:07:45'),
(12, 10, 'asasasas', 'asasa', '2020-04-06 01:37:45', '2020-04-06 02:07:45'),
(13, 10, 'asasasas', 'asasa', '2020-04-06 01:37:45', '2020-04-06 02:07:45'),
(14, 10, 'asasasas', 'asasa', '2020-04-06 01:37:45', '2020-04-06 02:07:45'),
(15, 10, 'asasasas', 'asasa', '2020-04-06 01:37:45', '2020-04-06 02:07:45'),
(16, 10, 'asasasas', 'asasa', '2020-04-06 01:37:45', '2020-04-06 02:07:45'),
(17, 10, 'asasasas', 'asasa', '2020-04-06 01:37:45', '2020-04-06 02:07:45'),
(18, 10, 'kjhjbjhb', 'jbjhb', '2020-04-06 01:40:17', '2020-04-06 02:10:17'),
(19, 10, 'asasa', 'sasas', '2020-04-06 01:50:22', '2020-04-06 02:20:22'),
(20, 10, 'asdsad', 'dasdasdasd', '2020-04-06 01:51:48', '2020-04-06 02:51:48'),
(21, 12, 'Job Description', 'Client Fake Name', '2020-04-06 02:06:09', '2020-04-06 02:36:09');

-- --------------------------------------------------------

--
-- Структура таблицы `jobtasks`
--

CREATE TABLE `jobtasks` (
  `TaskId` int(11) DEFAULT NULL,
  `JobId` int(11) DEFAULT NULL,
  `OperatingCost` decimal(13,2) NOT NULL,
  `OperatingRevenue` decimal(13,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `jobtasks`
--

INSERT INTO `jobtasks` (`TaskId`, `JobId`, `OperatingCost`, `OperatingRevenue`) VALUES
(1, 2, '66.00', '197.00'),
(1, 3, '12.00', '36.00'),
(2, 3, '24.00', '72.00'),
(3, 3, '12.00', '36.00'),
(1, 4, '12.00', '36.00'),
(1, 5, '12.00', '36.00'),
(1, 6, '12.00', '36.00'),
(2, 7, '24.00', '72.00'),
(1, 10, '12.00', '36.00'),
(1, 11, '12.00', '36.00'),
(1, 12, '12.00', '36.00'),
(1, 13, '12.00', '36.00'),
(1, 14, '12.00', '36.00'),
(1, 15, '12.00', '36.00'),
(1, 16, '12.00', '36.00'),
(1, 17, '12.00', '36.00'),
(1, 18, '12.00', '36.00'),
(1, 19, '12.00', '36.00'),
(2, 20, '24.00', '72.00'),
(1, 21, '12.00', '36.00');

-- --------------------------------------------------------

--
-- Структура таблицы `tasks`
--

CREATE TABLE `tasks` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Duration` int(11) NOT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `tasks`
--

INSERT INTO `tasks` (`Id`, `Name`, `Description`, `Duration`, `CreatedAt`, `UpdatedAt`, `IsDeleted`) VALUES
(1, 'MikeTest', 'this is a task for MikeTest', 30, NULL, NULL, b'0'),
(2, 'C#', 'We need a specialist for C#', 60, NULL, NULL, b'0'),
(3, 'PHP', 'test for PHP', 30, NULL, NULL, b'0'),
(4, 'MikeTest Updated', 'this is a task for MikeTest Updated', 60, NULL, NULL, b'0'),
(5, 'MikeTest2', 'this is a task for MikeTest2', 30, NULL, '2020-03-31 22:43:56', b'0');

-- --------------------------------------------------------

--
-- Структура таблицы `teammembers`
--

CREATE TABLE `teammembers` (
  `EmployeeId` int(11) DEFAULT NULL,
  `TeamId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `teammembers`
--

INSERT INTO `teammembers` (`EmployeeId`, `TeamId`) VALUES
(33, 10),
(34, 10),
(33, 11),
(34, 11),
(33, 12),
(34, 12),
(35, 13),
(35, 13),
(33, 14),
(33, 14),
(36, 15),
(37, 15);

-- --------------------------------------------------------

--
-- Структура таблицы `teams`
--

CREATE TABLE `teams` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `IsOnCall` bit(1) NOT NULL,
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0',
  `CreatedAt` datetime DEFAULT NULL,
  `DeletedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `teams`
--

INSERT INTO `teams` (`Id`, `Name`, `IsOnCall`, `IsDeleted`, `CreatedAt`, `DeletedAt`, `UpdatedAt`) VALUES
(10, 'Team Deleted', b'0', b'0', NULL, '2020-03-31 20:51:33', NULL),
(11, 'DOESNT HAVE TEAM BUT DELETED', b'0', b'0', NULL, '2020-03-31 21:29:04', NULL),
(12, 'Test team', b'0', b'0', NULL, '2020-03-31 21:38:01', NULL),
(13, 'lest test team', b'1', b'0', NULL, '2020-03-31 22:06:10', NULL),
(14, 'ajkdnaskjd', b'0', b'0', NULL, NULL, NULL),
(15, 'Test Team For PRESENTATION', b'0', b'0', NULL, NULL, NULL);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `employeesstasks`
--
ALTER TABLE `employeesstasks`
  ADD PRIMARY KEY (`EmployeeId`,`TaskId`) USING BTREE,
  ADD KEY `employee` (`EmployeeId`),
  ADD KEY `task` (`TaskId`);

--
-- Индексы таблицы `jobs`
--
ALTER TABLE `jobs`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `team_fk` (`TeamId`);

--
-- Индексы таблицы `jobtasks`
--
ALTER TABLE `jobtasks`
  ADD KEY `task_fk` (`TaskId`),
  ADD KEY `job_fk` (`JobId`);

--
-- Индексы таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `teammembers`
--
ALTER TABLE `teammembers`
  ADD KEY `amployee` (`EmployeeId`),
  ADD KEY `team` (`TeamId`);

--
-- Индексы таблицы `teams`
--
ALTER TABLE `teams`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `employees`
--
ALTER TABLE `employees`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT для таблицы `jobs`
--
ALTER TABLE `jobs`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT для таблицы `tasks`
--
ALTER TABLE `tasks`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `teams`
--
ALTER TABLE `teams`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `jobtasks`
--
ALTER TABLE `jobtasks`
  ADD CONSTRAINT `job_fk` FOREIGN KEY (`JobId`) REFERENCES `jobs` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `task_fk` FOREIGN KEY (`TaskId`) REFERENCES `tasks` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `teammembers`
--
ALTER TABLE `teammembers`
  ADD CONSTRAINT `amployee` FOREIGN KEY (`EmployeeId`) REFERENCES `employees` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `team` FOREIGN KEY (`TeamId`) REFERENCES `teams` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
