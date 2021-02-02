/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.models.IJob;
import java.util.List;

/**
 *
 * @author Nik
 */
public interface IJobRepository {
    IJob insertJob(IJob job);
    int updateJob(IJob job);
    int deleteJob(int id);
    List<IJob> retrieveJobs();
    IJob retrieveJob(int id);
}
