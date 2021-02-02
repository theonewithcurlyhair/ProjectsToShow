package com.alpha.models;

import java.io.Serializable;
import java.util.ArrayList;

public class Base implements IBase, Serializable{

    private ArrayList<IError> errors = ErrorFactory.createListInstance();
    
    @Override
    public ArrayList<IError> getErrors() {
        return errors;
    }

    @Override
    public void addError(IError error) {
        errors.add(error);
    }
    
    
    
}
