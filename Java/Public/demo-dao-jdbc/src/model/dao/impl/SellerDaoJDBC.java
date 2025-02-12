package model.dao.impl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import db.DBConnection;
import db.exceptions.DbException;
import model.dao.SellerDao;
import model.entities.Department;
import model.entities.Seller;

public class SellerDaoJDBC implements SellerDao {

	private Connection connection;

	public SellerDaoJDBC(Connection connection) {
		this.connection = connection;
	}

	@Override
	public void insert(Seller seller) {
		// TODO Auto-generated method stub

	}

	@Override
	public void update(Seller seller) {
		// TODO Auto-generated method stub

	}

	@Override
	public void deleteById(Integer id) {
		// TODO Auto-generated method stub

	}

	@Override
	public Seller findById(Integer id) {

		PreparedStatement pstmt = null;
		ResultSet rs = null;
		String sqlCommand = "SELECT seller.*, department.Name as DepName FROM seller INNER JOIN department "
				+ "ON seller.DepartmentId = department.Id WHERE seller.Id = ?";

		try {
			pstmt = connection.prepareStatement(sqlCommand);
			pstmt.setInt(1, id);
			rs = pstmt.executeQuery();

			if (rs.next()) {
				Department department = instantiateDepartment(rs);
				Seller seller = instantiateSeller(rs, department);
				return seller;
			}

			return null; // If no seller was found by the given ID

		} catch (SQLException e) {
			throw new DbException(e.getMessage());
		} finally {
			DBConnection.closeStatement(pstmt);
			DBConnection.closeResultSet(rs);
		}
	}

	private Department instantiateDepartment(ResultSet rs) throws SQLException {
		int departmentId = rs.getInt("DepartmentId");
		String departmentName = rs.getString("DepName");
		Department department = new Department(departmentId, departmentName);

		return department;
	}

	private Seller instantiateSeller(ResultSet rs, Department department) throws SQLException {
		int sellerId = rs.getInt("Id");
		String sellerName = rs.getString("Name");
		String sellerEmail = rs.getString("Email");
		LocalDate sellerDate = rs.getDate("BirthDate").toLocalDate();
		double sellerBaseSalary = rs.getDouble("BaseSalary");
		Seller seller = new Seller(sellerId, sellerName, sellerEmail, sellerDate, sellerBaseSalary, department);
		return seller;
	}

	@Override
	public List<Seller> findAll() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Seller> findByDepartment(Department department) {

		PreparedStatement pstmt = null;
		ResultSet rs = null;
		String sqlCommand = "SELECT seller.*, department.Name as DepName " + "FROM seller INNER JOIN department "
				+ "ON seller.DepartmentId = department.Id WHERE DepartmentId = ? ORDER BY Name";

		try {
			pstmt = connection.prepareStatement(sqlCommand);
			pstmt.setInt(1, department.getId());
			rs = pstmt.executeQuery();
			List<Seller> list = new ArrayList<Seller>();
			Map<Integer, Department> map = new HashMap<>();

			while (rs.next()) {
				Department dep = map.get(rs.getInt("DepartmentId"));

				if (dep == null) {
					dep = instantiateDepartment(rs);
					map.put(rs.getInt("DepartmentId"), dep);
				}

				Seller seller = instantiateSeller(rs, dep);
				list.add(seller);
			}

			return list;

		} catch (SQLException e) {
			throw new DbException(e.getMessage());
		} finally {
			DBConnection.closeStatement(pstmt);
			DBConnection.closeResultSet(rs);
		}
	}
}
