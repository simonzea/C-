namespace Models;

public class Person {

 public int Id { get; set; }
 public string? Name { get; set; }
 public string? UserName { get; set; }
 public string? Email { get; set; }

 public string? Phone { get; set; }
 public string? Website { get; set; }

 public Address? Address { get; set; }
 public Company? Company { get; set; }

  public List<Todo>? Todos { get; set; }

}


public class Address {

 public string? Street { get; set; }
 public string Suite { get; set; }
 public string City { get; set; }
 public string Zipcode { get; set; }
 public Geo Geo { get; set; }

}

public class Geo {

 public string Lat { get; set; }
 public string? Lng { get; set; }

}

public class Company {
public string? Name { get; set; }

 public string? CatchPhrase { get; set; }
 public string? Bs { get; set; }

}

public class Todo {
public int UserId { get; set; }

public int Id { get; set; }

 public string? Title { get; set; }
 public bool Completed { get; set; }

}
