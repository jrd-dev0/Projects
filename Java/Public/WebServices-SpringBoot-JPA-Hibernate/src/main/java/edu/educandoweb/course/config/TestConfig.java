package edu.educandoweb.course.config;

import java.time.Instant;
import java.util.Arrays;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Profile;

import edu.educandoweb.course.entities.Order;
import edu.educandoweb.course.entities.User;
import edu.educandoweb.course.repositories.OrderRepository;
import edu.educandoweb.course.repositories.UserRepository;

@Configuration
@Profile("test")
public class TestConfig implements CommandLineRunner{

	@Autowired
	private UserRepository userRepository;
	
	@Autowired
	private OrderRepository orderRepository;

	@Override
	public void run(String... args) throws Exception {
		
		User u1 = new User(null, "Maria Brown", "maria@gmail.com", "988888888", "123456"); 
		User u2 = new User(null, "Alex Green", "alex@gmail.com", "977777777", "123456"); 
		User u3 = new User(null, "Roberval Grey", "roberval@gmail.com", "155877771", "123456");
		User u4 = new User(null, "Hommer Red", "hommer@gmail.com", "155866662", "123456");
		User u5 = new User(null, "Paty Pink", "pati.piky@gmail.com", "155888881", "123456");
		User u6 = new User(null, "Mia Star", "mia@gmail.com", "1555696969", "123456");
		
		Order o1 = new Order(null, Instant.parse("2019-06-20T19:53:07Z"), u1); 
		Order o2 = new Order(null, Instant.parse("2019-07-21T03:42:10Z"), u2); 
		Order o3 = new Order(null, Instant.parse("2020-07-22T15:21:22Z"), u1);
		Order o4 = new Order(null, Instant.parse("2020-04-20T10:50:07Z"), u3);
		Order o5 = new Order(null, Instant.parse("2021-06-17T19:53:07Z"), u4);
		Order o6 = new Order(null, Instant.parse("2021-03-19T19:53:07Z"), u6);
		Order o7 = new Order(null, Instant.parse("2021-04-11T15:31:07Z"), u3);
		Order o8 = new Order(null, Instant.parse("2021-04-10T10:10:07Z"), u6);
		Order o9 = new Order(null, Instant.parse("2021-11-07T19:53:07Z"), u2);
		
		userRepository.saveAll(Arrays.asList(u1, u2, u3, u4, u5, u6));
		orderRepository.saveAll(Arrays.asList(o1, o2, o3, o4, o5, o6, o7, o8, o9));
	}
}
