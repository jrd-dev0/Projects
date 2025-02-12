package application;

import java.time.LocalDate;

import model.dao.DaoFactory;
import model.dao.SellerDao;
import model.entities.Department;
import model.entities.Seller;

public class Program {

	public static void main(String[] args) {
		
		Department dep1 = new Department(1, "Books");
		Seller seller = new Seller(1, "Bob", "bob@gmail.com", LocalDate.now(), 3000.00, dep1);
		
		SellerDao sellerDao = DaoFactory.createSellerDao();
		
		System.out.println(dep1);
		System.out.println(seller);

	}
}