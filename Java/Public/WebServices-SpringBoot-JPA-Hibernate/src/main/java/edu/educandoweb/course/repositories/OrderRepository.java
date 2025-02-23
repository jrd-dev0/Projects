package edu.educandoweb.course.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import edu.educandoweb.course.entities.Order;

public interface OrderRepository extends JpaRepository<Order, Long> {

}