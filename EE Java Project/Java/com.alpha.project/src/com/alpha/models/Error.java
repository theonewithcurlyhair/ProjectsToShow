package com.alpha.models;

public class Error implements IError{
    
    private int code;
    private String description;

    @Override
    public int getCode() {
       return code;
    }

    @Override
    public void setCode(int code) {
        this.code = code;
    }

    @Override
    public String getDescription() {
        return description;
    }

    @Override
    public void setDescription(String description) {
        this.description = description;
    }
    
    public Error(){
        
    }
    
    public Error(int code, String description){
        this.setCode(code);
        this.setDescription(description);
        
    }
    
}
