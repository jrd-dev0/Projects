package edu.educandoweb.course.services.exceptions;

public class ResourceNotFoundException extends RuntimeException{

	private static final long serialVersionUID = 1L;
	
	public ResourceNotFoundException(Object id) {
		super(String.format("Resource not found. Id %d", id));
	}

}