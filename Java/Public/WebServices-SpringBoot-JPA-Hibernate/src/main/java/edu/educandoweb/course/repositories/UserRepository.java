package edu.educandoweb.course.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import edu.educandoweb.course.entities.User;

public interface UserRepository extends JpaRepository<User, Long> {

}