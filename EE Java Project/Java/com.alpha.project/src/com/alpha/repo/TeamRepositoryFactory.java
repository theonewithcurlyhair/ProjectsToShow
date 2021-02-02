/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

/**
 *
 * @author MSI
 */
public class TeamRepositoryFactory extends BaseRepository{
        public static ITeamRepository createInstance(){
              
        return new TeamRepository() ;
    }
}
