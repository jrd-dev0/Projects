package model.dao.impl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import db.DBConnection;
import db.exceptions.DbException;
import model.dao.DepartmentDao;
import model.entities.Department;

public class DepartmentDaoJDBC implements DepartmentDao {

	private Connection connection;

	public DepartmentDaoJDBC(Connection connection) {
		this.connection = connection; 
	}
	
	@Override
	public void insert(Department department) {
		PreparedStatement statement = null;
		String sqlCommand = "INSERT INTO department (Name) VALUES (?)";

		try {
			statement= connection.prepareStatement(sqlCommand, Statement.RETURN_GENERATED_KEYS);
			statement.setString(1, department.getName());

			int rowsAffected = statement.executeUpdate();

			if (rowsAffected > 0) {
				ResultSet generatedKeys = statement.getGeneratedKeys();
				if (generatedKeys.next()) {
					int id = generatedKeys.getInt(1);
					department.setId(id);
				}
				DBConnection.closeResultSet(generatedKeys);
			}
			else{
				throw new SQLException("Unexpected error! no rows affected.");
			}
				
		} catch (SQLException e) {
			throw new DbException(e.getMessage());
		} finally {
			DBConnection.closeStatement(statement);
		}
	}

	@Override
	public void update(Department department) {
		PreparedStatement statement = null;
		String sqlCommand = "UPDATE department SET Name = ? WHERE Id = ?";

		try {
			statement = connection.prepareStatement(sqlCommand);
			statement.setString(1, department.getName());
			statement.setInt(2, department.getId());

			int rowsAffected = statement.executeUpdate();
			
			if (rowsAffected == 0) {
                System.out.printf("No rows affected! Department with id %d not found.%n", department.getId());
            }

		} catch (SQLException e) {
			throw new DbException(e.getMessage());
		} finally {
			DBConnection.closeStatement(statement);
		}
		
	}

	@Override
	public void deleteById(Integer id) {
		PreparedStatement statement = null;
		String sqlCommand = "DELETE FROM department WHERE Id = ?";

		try {
			statement = connection.prepareStatement(sqlCommand);
			statement.setInt(1, id);

			int rowsAffected = statement.executeUpdate();
			
			if (rowsAffected == 0) {
                System.out.printf("No rows affected! Department with id %d not found.%n", id);
            }

		} catch (SQLException e) {
			throw new DbException(e.getMessage());
		} finally {
			DBConnection.closeStatement(statement);
		}
		
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
		

		try {
			statement = connection.prepareStatement(sqlCommand);
			resultSet = statement.executeQuery();
			List<Department> departmentList = new ArrayList<>();

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
