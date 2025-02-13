package model.dao.impl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import db.DBConnection;
import db.exceptions.DbException;
import model.dao.DepartmentDao;
import model.entities.Department;
import model.entities.Seller;

public class DepartmentDaoJDBC implements DepartmentDao {

	private Connection connection;

	public DepartmentDaoJDBC(Connection connection) {
		this.connection = connection; 
	}
	
	@Override
	public void insert(Department department) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void update(Department department) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void deleteById(Integer id) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public Department findById(Integer id) {
		PreparedStatement statement = null;
		ResultSet resultSet = null;
		String sqlCommand = "SELECT * FROM department WHERE Id  = ?";

		try {
			statement = connection.prepareStatement(sqlCommand);
			statement.setInt(1, id);
			resultSet = statement.executeQuery();

			if (resultSet.next()) {
				Department department = instantiateDepartment(resultSet);
				return department;
			}

			return null; // If no department was found by the given ID

		} catch (SQLException e) {
			throw new DbException(e.getMessage());
		} finally {
			DBConnection.closeStatement(statement);
			DBConnection.closeResultSet(resultSet);
		}

	}

	private Department instantiateDepartment(ResultSet resultSet) throws SQLException {
		int departmentId = resultSet.getInt("Id");
		String departmentName = resultSet.getString("Name");
		Department department = new Department(departmentId, departmentName);

		return department;
	}

	@Override
	public List<Department> findAll() {
		PreparedStatement statement = null;
		ResultSet resultSet = null;
		String sqlCommand = "SELECT * FROM department ORDER BY Name";
		List<Department> departmentList = new ArrayList<>();

		try {
			statement = connection.prepareStatement(sqlCommand);
			resultSet = statement.executeQuery();
			List<Seller> list = new ArrayList<Seller>();

			while (resultSet.next()) {

				Department department = instantiateDepartment(resultSet);
				departmentList.add(department);
			}

			return departmentList;
		} catch (SQLException e) {
			throw new DbException(e.getMessage());
		} finally {
			DBConnection.closeStatement(statement);
			DBConnection.closeResultSet(resultSet);
		}
	}
}
