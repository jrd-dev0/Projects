package application;

import java.time.LocalDate;
import java.util.List;

import model.dao.DaoFactory;
import model.dao.DepartmentDao;
import model.dao.SellerDao;
import model.entities.Department;
import model.entities.Seller;

public class Program {

	public static void main(String[] args) {

		DepartmentDao departmentDao = DaoFactory.createDepartmentDao();
		
		System.out.println("==== TEST 1: Department findById ====");
		Department department = departmentDao.findById(3);
		System.out.println(department);
		
		System.out.println();
		System.out.println("==== TEST 2: Department findAll ====");
		List<Department> departmentList = departmentDao.findAll();
		for(Department dep : departmentList) {
			System.out.println(dep);
		}
		
//		SellerDao sellerDao = DaoFactory.createSellerDao();
//
//		System.out.println("==== TEST 1: Seller findById ====");
//		Seller seller = sellerDao.findById(3);
//		System.out.println(seller);
//		
//		System.out.println();
//		System.out.println("==== TEST 2: Seller findByDepartment ====");
//		Department dep1 = new Department(2, null);	
//		List<Seller> sellerList = sellerDao.findByDepartment(dep1);
//		for(Seller s : sellerList) {
//			System.out.println(s);
//		}
//		
//		System.out.println();
//		System.out.println("==== TEST 3: Seller findAll ====");
//		sellerList = sellerDao.findAll();
//		for(Seller s : sellerList) {
//			System.out.println(s);
//		}
//		
//		System.out.println();
//		System.out.println("==== TEST 4: Seller insert ====");
//		Seller newSeller = new Seller(null, "Alice", "alice@gmail.com", LocalDate.now(), 4000.00, dep1);
//		sellerDao.insert(newSeller);
//		System.out.printf("Inserted! New id = %d%n", newSeller.getId());
//		
//		System.out.println();
//		System.out.println("==== TEST 5: Seller Update ====");
//		seller = sellerDao.findById(1);
//		seller.setBaseSalary(8000.00);
//		sellerDao.update(seller);
//		System.out.println("Updated completed!");
//		
//		System.out.println();
//		System.out.println("==== TEST 6: Seller Delete ====");
//		sellerDao.deleteById(3);
//		System.out.println("Delete command completed!");
	}
}