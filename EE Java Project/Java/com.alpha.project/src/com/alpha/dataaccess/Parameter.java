/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.dataaccess;
/**
 *
 * @author Chris.Cusack
 */
public class Parameter extends ParameterFactory implements IParameter {

    private Object value;
    private Direction direction;
    private int sqlType;

    Parameter() {
        this.direction = Direction.IN;
    }

    Parameter(Object value) {
        this.value = value;
        this.direction = Direction.IN;
    }

    Parameter(Object value, Direction direction) {
        this.value = value;
        this.direction = direction;
    }

    Parameter(Object value,Direction direction, int sqlType) {
        this.value = value;
        this.direction = direction;
        this.sqlType = sqlType;
    }

    @Override
    public Object getValue() {
        return value;
    }

    @Override
    public void setValue(Object value) {
        this.value = value;
    }

    @Override
    public Direction getDirection() {
        return direction;
    }

    @Override
    public void setDirection(Direction direction) {
        this.direction = direction;
    }

    @Override
    public void setSQLType(int sqlType) {
        this.sqlType = sqlType;
    }

    @Override
    public int getSQLType() {
        return this.sqlType;
    }
}
