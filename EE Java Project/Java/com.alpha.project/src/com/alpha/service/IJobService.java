/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.IJob;
import java.util.List;

/**
 *
 * @author Nik
 */
public interface IJobService {
    IJob createJob(IJob Job);
    int saveJob(IJob Job);
    int deleteJob(int id);
    
    IJob getJob(int id);
    List<IJob> getJobs();
}
