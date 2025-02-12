package db;

import db.exceptions.DbException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class DBConnection {
	
	private static Connection conn = null;

    private DBConnection() {
    }

    public static Connection getConnection() {
    	
        if (conn == null) {
        	
            try {
                String url = DBPropertiesLoader.getProperty("db.url");
                String user = DBPropertiesLoader.getProperty("db.user");
                String password = DBPropertiesLoader.getProperty("db.password");

                conn = DriverManager.getConnection(url, user, password);
                
            } catch (SQLException e) {
                throw new DbException(e.getMessage());
            }
        }
        
        return conn;
    }

    public static void closeConnection() {
    	
        if (conn != null) {
        	
            try {
            	
                conn.close();
                
            } catch (SQLException e) {
                throw new DbException(e.getMessage());
            }
        }
    }
    
    public static void closeStatement(Statement st) {
    	
    	if (st!= null) {
    		
    		try {
			
    			st.close();
			
    		} catch (SQLException e) {
				throw new DbException(e.getMessage());
			}
    	}
    }
    
    public static void closeResultSet(ResultSet rs) {
    	
	    if (rs!= null) {
	    	
	    	try {
				
    			rs.close();
			
    		} catch (SQLException e) {
				throw new DbException(e.getMessage());
			}
    	}
    }
}
