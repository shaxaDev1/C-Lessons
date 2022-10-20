﻿using AutoText.WeB.Models;
using AutoText.WeB.Repositories;

namespace AutoText.WeB.Services;

public class UsersService
{
    private readonly CookiesService _cookiesService;
    private readonly UsersRepository _usersRepository;

    public UsersService()
    {
        _cookiesService = new CookiesService();
        _usersRepository = new UsersRepository();
    }
    public User? GetUserFromCookie(HttpContext context)
    {
        var userPhone = _cookiesService.GetUserPhoneFromCookie(context);
        if(userPhone != null)
        {
            var user = _usersRepository.GetUserByPhoneNumber(userPhone);
            if(user.Phone == userPhone)
            {
                return user;
            }
        }
        return null;
    }
}
