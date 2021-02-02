/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.GetTeamsDto;
import com.alpha.repo.HomeRepository;
import java.util.List;
import java.util.Map;

/**
 *
 * @author MSI
 */
public class HomeService {

    private HomeRepository repo = new HomeRepository();

    public Map<String, List<Double>> GetDataForCurrentAndPrevYear() {
        return repo.retrieveDataForCalendar();
    }
    
    public int currentDayCountOfJobs(){
        return repo.currentDayCountOfJobs();
    }
    
    public GetTeamsDto getOnCallTeam() {
        return repo.getOnCallTeam();
    }
    
}
