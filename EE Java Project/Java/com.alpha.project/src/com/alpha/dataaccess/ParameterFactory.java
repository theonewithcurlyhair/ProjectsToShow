
package com.alpha.dataaccess;
import java.util.ArrayList;

/**
 * @date 2020-02-27
 * @author Nikita Mieshalnykov
 */
public abstract class ParameterFactory {

    public static IParameter createInstance() {
        return new Parameter();
    }

    public static IParameter createInstance(Object value) {
        return new Parameter(value);
    }

    public static IParameter createInstance(Object value, IParameter.Direction direction) {
        return new Parameter(value, direction);

    }

    public static IParameter createInstance(Object value, IParameter.Direction direction, int sqlType) {
        return new Parameter(value, direction, sqlType);

    }
    
    public static ArrayList<IParameter> createListInstance(){
        return new ArrayList<>();
    }
}
