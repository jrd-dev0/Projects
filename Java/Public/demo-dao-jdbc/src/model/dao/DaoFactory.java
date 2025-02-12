package model.dao;

import db.DBConnection;
import model.dao.impl.SellerDaoJDBC;

public class DaoFactory {

	public static SellerDao createSellerDao() {
		return new SellerDaoJDBC(DBConnection.getConnection()); // Implementando a interface SellerDao com o método de persistência JDBC
	}
}
