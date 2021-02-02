/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.models;

import com.alpha.models.IJob;
import com.alpha.models.Job;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Nik
 */
public class JobViewModel {

    /**
     * @return the jobs
     */
    public List<IJob> getJobs() {
        return jobs;
    }

    /**
     * @param jobs the jobs to set
     */
    public void setJobs(List<IJob> jobs) {
        this.jobs = jobs;
    }
    private IJob job = new Job();
    private List<IJob> jobs = new ArrayList();
    public JobViewModel(){}
    
    public IJob getJob(){
        return job;
    }
    
    public void setJob(IJob job){
        this.job = job;
    }
}
