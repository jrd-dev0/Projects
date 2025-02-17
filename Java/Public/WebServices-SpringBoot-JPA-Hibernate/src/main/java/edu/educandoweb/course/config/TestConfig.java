package edu.educandoweb.course.config;

import java.util.Arrays;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Profile;

import edu.educandoweb.course.entities.User;
import edu.educandoweb.course.repositories.UserRepository;

@Configuration
@Profile("test")
public class TestConfig implements CommandLineRunner{

	@Autowired
	private UserRepository userRepository;

	@Override
	public void run(String... args) throws Exception {
		
		User u1 = new User(null, "Maria Brown", "maria@gmail.com", "988888888", "123456"); 
		User u2 = new User(null, "Alex Green", "alex@gmail.com", "977777777", "123456"); 
		User u3 = new User(null, "Roberval Grey", "roberval@gmail.com", "155877771", "123456");
		User u4 = new User(null, "Hommer Red", "hommer@gmail.com", "155866662", "123456");
		User u5 = new User(null, "Paty Pink", "pati.piky@gmail.com", "155888881", "123456");
		User u6 = new User(null, "Mia Star", "mia@gmail.com", "1555696969", "123456");
		
		userRepository.saveAll(Arrays.asList(u1, u2, u3, u4, u5, u6));
	}
}
