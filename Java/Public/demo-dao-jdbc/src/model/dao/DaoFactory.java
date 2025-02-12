package model.dao;

import model.dao.impl.SellerDaoJDBC;

public class DaoFactory {

	public static SellerDao createSellerDao() {
		return new SellerDaoJDBC(); // Implementando a interface SellerDao com o método de persistência JDBC
	}
}
