package edu.educandoweb.course.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import edu.educandoweb.course.entities.Category;

public interface CategoryRepository extends JpaRepository<Category, Long> {

}