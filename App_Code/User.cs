using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public User()
    {
    }

    public User(string ID, string email, string firstname, string lastname, string city, string address, string password, int permission)
    {
        this.password = password;
        this.email = email;
        this.firstName = firstname;
        this.lastName = lastname;
        this.id = ID;
        this.city = city;
        this.address = address;
        this.permission = permission;
    }

    private string firstName, lastName, password, email, id, city, address;
    private int permission;

    public string ID
    {
        get { return this.id; }
        set { this.id = value; }
    }
    public string Password
    {
        get { return this.password; }
        set { this.password = value; }
    }
    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }
    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }
    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }
    public string City
    {
        get { return this.city; }
        set { this.city = value; }
    }
    public string Address
    {
        get { return this.address; }
        set { this.address = value; }
    }
    public int Permission
    {
        get { return this.permission; }
        set { this.permission = value; }
    }

}