/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.controllers;

import com.alpha.models.IGetTeamsDto;
import com.web.models.TeamViewModel;
import com.alpha.models.IJob;
import com.alpha.models.IJobTask;
import com.alpha.models.ITask;
import com.alpha.models.ITeam;
import com.alpha.models.Job;
import com.alpha.models.JobTask;
import com.alpha.models.Task;
import com.alpha.service.IJobService;
import com.alpha.service.IJobTaskService;
import com.alpha.service.ITaskService;
import com.alpha.service.ITeamService;
import com.alpha.service.JobServiceFactory;
import com.alpha.service.JobTaskService;
import com.alpha.service.JobTaskServiceFactory;
import com.alpha.service.TaskServiceFactory;
import com.alpha.service.TeamServiceFactory;
import com.web.models.ErrorViewModel;
import com.web.models.JobTaskViewModel;
import com.web.models.JobViewModel;
import com.web.models.TaskViewModel;
import java.io.IOException;
import static java.lang.Character.compare;
import java.util.ArrayList;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.joda.time.DateTime;
import java.util.regex.*;
import java.util.stream.Collectors;

/**
 *
 * @author Nik
 */
//Steps
//1) Populatr teams - then only available teams with brs
//2)
public class JobController extends CommonController {

    private static final String JOBS_VIEW = "/jobs.jsp";
    private static final String JOBS_MAINT_VIEW = "/job.jsp";
    private static final String JOB_SUMMARY_VIEW = "/jobSummary.jsp";
    private final IJobService jobService = JobServiceFactory.createInstance();
    private final ITeamService teamSerivce = TeamServiceFactory.createInstance();
    private final ITaskService taskService = TaskServiceFactory.createInstance();
    private final IJobTaskService jobTaskService = JobTaskServiceFactory.createInstance();

    @Override
    public String getServletInfo() {
        return "Short description";
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            String path = request.getPathInfo();
            if (path == null) {
                JobViewModel jobVm = new JobViewModel();
                jobVm.setJobs(jobService.getJobs());
                request.setAttribute("vm", jobVm);
                super.setView(request, JOBS_VIEW);
            } else {
                //asking for job summary page
                int id = super.getInteger(path.split("/")[1]);

                if (id != 0) {

                    //Get job details as vm
                    JobViewModel vmJob = new JobViewModel();
                    vmJob.setJob(jobService.getJob(id));
                    request.setAttribute("vmJob", vmJob);

                    //Get team details for job as vm
                    TeamViewModel vmTeam = new TeamViewModel();
                    vmTeam.setTeam(teamSerivce.getTeam(vmJob.getJob().getTeamId()));
                    request.setAttribute("vmTeam", vmTeam);

                    //Get the job tasks for job as vm
                    JobTaskViewModel vmJobTask = new JobTaskViewModel();
                    vmJobTask.setTasks(jobTaskService.getJobTasks(vmJob.getJob().getId()));
                    request.setAttribute("vmJobTask", vmJobTask);

                    //Get the tasks for jobtasks as vm
                    TaskViewModel vmTask = new TaskViewModel();
                    List<ITask> tasks = new ArrayList();
                    for (IJobTask jTask : vmJobTask.getTasks()) {
                        tasks.add(taskService.getTask(jTask.getTaskId()));
                    }
                    request.setAttribute("vmTask", vmTask);

                    super.setView(request, JOB_SUMMARY_VIEW);
                } else {
                    populateTasks(request);
                    super.setView(request, JOBS_MAINT_VIEW);
                }
            }
        } catch (Exception e) {
            super.setView(request, JOBS_MAINT_VIEW);
            request.setAttribute("error", new ErrorViewModel("An error occurred attempting to maintain jobs"));
        }

        super.getView().forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            String action = request.getParameter("action");
            if (action != null && action.equals("delete")) {
                jobService.deleteJob(super.getInteger(request.getParameter("jobId")));
            } else {
                populateTasks(request);
                loadTaskDetails(request);
                setJobViewModel(request);

                populateTeams(request);
                loadTeam(request);

                calculateJobTaskProps(request);

//            super.setView(request, JOBS_MAINT_VIEW);
                manipulateWithJob(request);
            }
        } catch (Exception e) {
            super.setView(request, JOBS_MAINT_VIEW);
            //request.setAttribute("error", new ErrorViewModel("An error occurred attempting to maintain jobs" + e.getMessage()));
        }

        super.getView().forward(request, response);
    }

    /**
     * Populating Job Properties from the Form Calculate end date time for the
     * job
     *
     * @param request
     * @param job
     */
    private void loadJobProperties(HttpServletRequest request, IJob job) {
        job.setTeamId(super.getInteger(request, "team"));
        job.setDescription(super.getValue(request, "description"));
        job.setClientName(super.getValue(request, "clientName"));
        job.setStart(new DateTime(super.getValue(request, "startDateTime")));

        TaskViewModel taskVm = (TaskViewModel) request.getAttribute("vmTask");
        if (taskVm != null && taskVm.getTasks() != null && !taskVm.getTasks().isEmpty()) {
            int totalDuration = 0;
            for (ITask t : taskVm.getTasks()) {
                totalDuration += t.getDuration();
            }

            job.calculateEndDateTime(totalDuration);
        }
    }

    /**
     * Populate select box team with available teams for the selected task
     *
     * @param request
     */
    private void populateTeams(HttpServletRequest request) {
        TaskViewModel taskVm = (TaskViewModel) request.getAttribute("vmTask");
        if (taskVm != null && taskVm.getTasks() != null && !taskVm.getTasks().isEmpty()) {
            List<IGetTeamsDto> teams = teamSerivce.getAvailableTeams(taskVm.getTasks());
            if (teams.isEmpty()) {
                request.setAttribute("error", new ErrorViewModel("No Available Teams"));
            } else {
                request.setAttribute("teams", teams);
            }
        }
    }

    /**
     * Triggers after team was selected from the select box Loads selected team
     * into view model
     *
     * @param request
     */
    private void loadTeam(HttpServletRequest request) {
        int team = super.getValue(request, "team") != null ? super.getInteger(request, "team") : 0;
        if (team > 0) {
            TeamViewModel teamVm = new TeamViewModel();
            teamVm.setTeam(teamSerivce.getTeam(team));
            request.setAttribute("vmTeam", teamVm);
        }
    }

    /**
     * Populate select box with all available tasks for the job to select
     *
     * @param request
     */
    private void populateTasks(HttpServletRequest request) {
        List<ITask> allTasks = taskService.getTasks();
        if (allTasks.isEmpty()) {
            request.setAttribute("error", new ErrorViewModel("No Tasks Added Yet"));
        } else {
            request.setAttribute("allTasks", allTasks);
        }
    }

    /**
     * Loads task details after task is selected from the select box Sets Task
     * View Model to session
     *
     * @param request
     */
    private void loadTaskDetails(HttpServletRequest request) {
        String selectedTasksString = request.getParameter("selectedTasks");
        selectedTasksString = selectedTasksString.replaceAll("[\"]|[\\[]|[\\]]", "");
        String[] selTasks = selectedTasksString.split(",");

        TaskViewModel vmTaskVm = new TaskViewModel();

        for (String taskId : selTasks) {
            vmTaskVm.addTaskToList(taskService.getTask(super.getInteger(taskId)));
        }

        List<ITask> allTasks = (List<ITask>) request.getAttribute("allTasks");
        if (!selectedTasksString.equals("")) {
            vmTaskVm.getTasks().forEach(t -> allTasks.removeAll(allTasks.stream().filter(x -> x.getId() == t.getId()).collect(Collectors.toList())));
        }
        request.setAttribute("vmTask", vmTaskVm);
        request.setAttribute("allTasks", allTasks);
    }

    /**
     * After team is selected receives calculated totals from the db
     *
     * @param request
     */
    private void calculateJobTaskProps(HttpServletRequest request) {
        TaskViewModel taskVm = (TaskViewModel) request.getAttribute("vmTask");
        TeamViewModel teamVm = (TeamViewModel) request.getAttribute("vmTeam");

        if (taskVm != null && teamVm != null) {
            JobTaskViewModel jobTaskVm = new JobTaskViewModel();
            List<IJobTask> jobTasks = new ArrayList();
            for (ITask task : taskVm.getTasks()) {
                IJobTask jobTaskToCreate = jobTaskService.getJobTaskTotals(task.getId(), teamVm.getTeam().getId());
                jobTasks.add(jobTaskToCreate);
            }

            jobTaskVm.setTasks(jobTasks);
            request.setAttribute("vmJobTask", jobTaskVm);
        }
    }

    /**
     * Sets JobViewModel to session
     *
     * @param request
     */
    private void setJobViewModel(HttpServletRequest request) {
        IJob job = new Job();
        loadJobProperties(request, job);
        JobViewModel vmJob = new JobViewModel();
        vmJob.setJob(job);

        request.setAttribute("vmJob", vmJob);
    }

    private void manipulateWithJob(HttpServletRequest request) {
        TaskViewModel taskVm = (TaskViewModel) request.getAttribute("vmTask");
        TeamViewModel teamVm = (TeamViewModel) request.getAttribute("vmTeam");
        JobTaskViewModel jobTaskVm = (JobTaskViewModel) request.getAttribute("vmJobTask");
        JobViewModel jobVm = (JobViewModel) request.getAttribute("vmJob");
        String action = super.getValue(request, "action");
        if (taskVm != null && teamVm != null && jobTaskVm != null && jobVm != null && action != null) {
            switch (action.toLowerCase()) {
                case "create":
                    IJob job = jobVm.getJob();
                    job.setTeamId(teamVm.getTeam().getId());
                    List<IJobTask> jobTasks = jobTaskVm.getTasks();
                    job = jobService.createJob(job);
                    for (IJobTask jTask : jobTasks) {
                        jTask.setJobId(job.getId());
                        jobTaskService.createJobTask(jTask);
                    }

                    jobVm.setJob(job);
                    request.setAttribute("vmJob", jobVm);
                    request.setAttribute("msg", "Job Was Successfully Created");
                    
                    jobVm = new JobViewModel();
                    jobVm.setJobs(jobService.getJobs());
                    request.setAttribute("vm", jobVm);
                    super.setView(request, JOBS_VIEW);
                    break;
            }
        }
    }
}
