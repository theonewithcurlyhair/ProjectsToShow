package com.alpha.models;

import java.util.ArrayList;

public abstract class ErrorFactory {
    
    public static IError createInstance(){
        return new Error();
    }
    
    
    public static IError createInstance(int code, String description){
        return new Error(code, description);
    }
    
    public static ArrayList<IError> createListInstance(){
        return new ArrayList<>();
    }
    
    
}
