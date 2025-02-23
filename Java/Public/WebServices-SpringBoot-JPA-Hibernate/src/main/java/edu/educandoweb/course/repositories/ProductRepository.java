package edu.educandoweb.course.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import edu.educandoweb.course.entities.Product;

public interface ProductRepository extends JpaRepository<Product, Long> {

}