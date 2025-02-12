package db;

import db.exceptions.DbException;
import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class DBPropertiesLoader {
	
	private static final Properties prop = new Properties();

    static {
    	
        try (InputStream input = DBPropertiesLoader.class.getClassLoader().getResourceAsStream("resources/db.properties")) {
        
        	if (input == null) {
                throw new DbException("Arquivo db.properties não encontrado!");
            }
        	
        	prop.load(input);
            
        } catch (IOException e) {
            throw new DbException(e.getMessage());
        }
    }

    public static String getProperty(String key) {
        return prop.getProperty(key);
    }
}
