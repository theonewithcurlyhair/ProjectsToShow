/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.dataaccess.DAL;
import com.alpha.dataaccess.IParameter;
import com.alpha.dataaccess.Parameter;
import com.alpha.dataaccess.ParameterFactory;
import com.alpha.models.EmployeeFactory;
import com.alpha.models.GetTeamsDtoFactory;
import com.alpha.models.IEmployee;
import com.alpha.models.IGetTeamsDto;
import com.alpha.models.ITask;
import com.alpha.models.ITeam;
import com.alpha.models.TeamFactory;
import java.sql.SQLException;
import java.sql.Types;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.sql.rowset.CachedRowSet;

/**
 *
 * @author Nik
 */
public class TeamRepository extends TeamRepositoryFactory implements ITeamRepository {

    private DAL dal = new DAL();

    @Override
    public int insertTeam(ITeam team) {
        //Populate parms list
        List<IParameter> parms = new ArrayList<IParameter>();
        parms.add(Parameter.createInstance(team.getIsOnCall() ? 1 : 0, IParameter.Direction.IN));
        parms.add(Parameter.createInstance(team.getName()));

        //Create output p
        IParameter idOut = Parameter.createInstance();
        idOut.setDirection(IParameter.Direction.OUT);
        idOut.setSQLType(0);
        idOut.setValue("idOut");
        parms.add(idOut);

        for (IEmployee e : team.getTeamMembers()) {
            parms.add(Parameter.createInstance(e.getId()));
        }

        return (int) dal.executeNonQuery("{call createTeam(?,?,?,?,?)}", parms).get(0); //exception index out of bound
    }

    @Override
    public int updateTeam(ITeam team) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public int deleteTeam(int id) {
        int returnId = 0;

        List<Object> returnValues;

        // Params list creation
        List<IParameter> params = ParameterFactory.createListInstance();

        params.add(ParameterFactory.createInstance(id));

        returnValues = dal.executeNonQuery("{call deleteTeams(?)}", params);

        try {
            if (returnValues != null) {
                returnId = Integer.parseInt(returnValues.get(0).toString());
            }
        } catch (Exception e) {
            System.out.print(e.getMessage());
        }

        return returnId;
    }

    @Override
    public List<IGetTeamsDto> retrieveTeams() {
        try {
            CachedRowSet rowSet = dal.executeFill("{call getTeams()}", null);
            List<IParameter> parms = new ArrayList<IParameter>();
            List<IGetTeamsDto> getTeams = new ArrayList();

            List<IEmployee> emps = EmployeeFactory.createListInstance();

            while (rowSet.next()) {
                IGetTeamsDto returnValues = GetTeamsDtoFactory.createInstance();
                ITeam retrievedTeam = TeamFactory.createInstance();
                int teamId = super.getInt("TeamId", rowSet);

                retrievedTeam.setId(super.getInt("Id", rowSet));
                retrievedTeam.setName(rowSet.getString("Name"));
                retrievedTeam.setDeletedAt(super.getDate("DeletedAt", rowSet));

                if (retrievedTeam.getDeletedAt() != null) {
                    retrievedTeam.setIsDeleted(true);
                }

                if (teamId != 0) {
                    retrievedTeam.setHasJob(true);
                }

                parms.add(Parameter.createInstance(retrievedTeam.getId()));
                CachedRowSet rowSetE = dal.executeFill("{call getTeamEmployees(?)}", parms);

                while (rowSetE.next()) {
                    IEmployee emp = EmployeeFactory.createInstance();
                    emp.setId(super.getInt("Id", rowSetE));
                    emp.setFirstName(rowSetE.getString("FirstName"));
                    emp.setLastName(rowSetE.getString("LastName"));

                    emps.add(emp);
                }

                returnValues.setTeamEmployees(emps);
                returnValues.setTeam(retrievedTeam);
                getTeams.add(returnValues);
            }

            return getTeams;
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    @Override
    public IGetTeamsDto retrieveTeam(int id) {
        IGetTeamsDto returnValues = GetTeamsDtoFactory.createInstance();
        try {
            List<IParameter> parms = new ArrayList<IParameter>();
            parms.add(Parameter.createInstance(id));
            CachedRowSet rowSet = dal.executeFill("{call getTeam(?)}", parms);

            List<IEmployee> emps = EmployeeFactory.createListInstance();

            returnValues = GetTeamsDtoFactory.createInstance();

            while (rowSet.next()) {
                ITeam retrievedTeam = TeamFactory.createInstance();
                int teamId = super.getInt("TeamId", rowSet);

                retrievedTeam.setId(super.getInt("Id", rowSet));
                retrievedTeam.setName(rowSet.getString("Name"));
                retrievedTeam.setDeletedAt(super.getDate("DeletedAt", rowSet));

                if (retrievedTeam.getDeletedAt() != null) {
                    retrievedTeam.setIsDeleted(true);
                }

                if (teamId != 0) {
                    retrievedTeam.setHasJob(true);
                }

                parms.add(Parameter.createInstance(retrievedTeam.getId()));
                CachedRowSet rowSetE = dal.executeFill("{call getTeamEmployees(?)}", parms);

                while (rowSetE.next()) {
                    IEmployee emp = EmployeeFactory.createInstance();
                    emp.setId(super.getInt("Id", rowSetE));
                    emp.setFirstName(rowSetE.getString("FirstName"));
                    emp.setLastName(rowSetE.getString("LastName"));

                    emps.add(emp);
                }

                returnValues.setTeamEmployees(emps);
                returnValues.setTeam(retrievedTeam);

            }
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
        return returnValues;
    }

    @Override
    public List<IEmployee> retrieveTeamMembers(int teamId) {
        try {
            List<IParameter> parms = new ArrayList<>();
            parms.add(Parameter.createInstance(teamId));
            CachedRowSet rowSet = dal.executeFill("{call sp_GetTeamMembers(?)}", parms);
            List<IEmployee> teamMembers = new ArrayList();
            while (rowSet.next()) {
                IEmployee e = EmployeeFactory.createInstance();
                e.setId(rowSet.getInt("EmployeeId"));
                teamMembers.add(e);
            }

            return teamMembers;
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class
                    .getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    @Override
    public List<ITeam> retrieveAvailableTeams(List<ITask> tasks) {
        try {
            String tasksIds = "";
            tasksIds = tasks.stream().map((t) -> t.getId() + ",").reduce(tasksIds, String::concat);
            tasksIds = tasksIds.substring(0, tasksIds.length() - 1);

            List<IParameter> parms = new ArrayList<>();
            parms.add(Parameter.createInstance(tasksIds));

            CachedRowSet rowSet = dal.executeFill("{call sp_GetTeamsWithMatchingSkills(?)}", parms);
            List<ITeam> teamsList = new ArrayList<ITeam>();
            while (rowSet.next()) {
                ITeam team = TeamFactory.createInstance();
                team.setName(rowSet.getString("Name"));
                team.setIsOnCall(rowSet.getBoolean("IsOnCall"));
                team.setId(rowSet.getInt("id"));
                team.setCreatedAt(rowSet.getDate("CreatedAt"));
                team.setDeletedAt(rowSet.getDate("DeletedAt"));
                team.setUpdatedAt(rowSet.getDate("UpdatedAt"));

                teamsList.add(team);
            }
            return teamsList;
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class
                    .getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    @Override
    public int setTeamOnCall(int id) {
        List<IParameter> parms = new ArrayList<>();
        parms.add(Parameter.createInstance(id));
        return (int) dal.executeScalar("{call sp_SetTeamOnCall}", parms);
    }
}
