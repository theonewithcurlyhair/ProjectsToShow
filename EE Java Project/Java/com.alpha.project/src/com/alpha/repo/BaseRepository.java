package com.alpha.repo;

import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.util.Date;
import javax.sql.rowset.CachedRowSet;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Nik
 */
public abstract class BaseRepository {

    /**
     * Helps get a column alias
     *
     * @param name
     * @param rs
     * @return
     * @throws SQLException
     */
    protected int getByColumnLabel(String name, CachedRowSet rs) throws SQLException {
        ResultSetMetaData rsmd = rs.getMetaData();
        int cols = rsmd.getColumnCount();
        int returnIndex = 0;
        for (int i = 1; i <= cols; ++i) {
            String colLabel = rsmd.getColumnLabel(i);
            String colName = rsmd.getColumnName(i);
            if (colName != null) {
                if (name.equalsIgnoreCase(colName) || name.equalsIgnoreCase(rsmd.getTableName(i) + "." + colName)) {
                    return (i);
                } else if (colLabel != null) {
                    if (name.equalsIgnoreCase(colLabel)) {
                        returnIndex = (i);
                    } else {
                        continue;
                    }
                }
            }
        }

        return returnIndex;
    }

    /**
     *
     * @param columnName
     * @param rs
     * @return
     * @throws SQLException
     */
    protected int getInt(String columnName, CachedRowSet rs) throws SQLException {
        int nValue = 0;
        nValue = rs.getInt(getByColumnLabel(columnName, rs));
        return nValue;
    }

    /**
     *
     * @param columnName
     * @param rs
     * @return
     * @throws SQLException
     */
    protected double getDouble(String columnName, CachedRowSet rs) throws SQLException {
        double nValue = 0.0;
        nValue = rs.getDouble(getByColumnLabel(columnName, rs));
        return nValue;
    }

    /**
     *
     * @param columnName
     * @param rs
     * @return
     * @throws SQLException
     */
    protected Date getDate(String columnName, CachedRowSet rs) throws SQLException {
        Date nValue = new Date();
        nValue = rs.getDate(getByColumnLabel(columnName, rs));
        return nValue;
    }
}
