package application;

import java.util.List;

import model.dao.DaoFactory;
import model.dao.SellerDao;
import model.entities.Department;
import model.entities.Seller;

public class Program {

	public static void main(String[] args) {

		SellerDao sellerDao = DaoFactory.createSellerDao();

		System.out.println("==== TEST 1: Seller findById ====");
		Seller seller = sellerDao.findById(3);
		System.out.println(seller);
		
		System.out.println();
		System.out.println("==== TEST 2: Seller findByDepartment ====");
		Department dep1 = new Department(2, null);	
		List<Seller> sellerList = sellerDao.findByDepartment(dep1);
		for(Seller s : sellerList) {
			System.out.println(s);
		}
		
		System.out.println();
		System.out.println("==== TEST 3: Seller findAll ====");
		sellerList = sellerDao.findAll();
		for(Seller s : sellerList) {
			System.out.println(s);
		}
	}
}