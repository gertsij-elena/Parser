﻿using System;
using System.Web.Mvc;
using CsQuery;
using Parser.Models;
using System.Linq;

namespace Parser.Controllers
{
    public class HomeController : Controller
    {
        DataContext _db = new DataContext();

        public ActionResult Index()
        {
            return View();
        } 
        public int SaveTeam(string name)
        {
            
                try
                {
                    int teamId = (from t in _db.Teams where t.TeamName == name select t.TeamId).FirstOrDefault();
                if (teamId>0)
                {
                    return teamId;
                }
                else
                {
                    Team team = new Team();
                    team.TeamName = name;
                    _db.Teams.Add(team);
                    _db.SaveChanges();
                    return team.TeamId;
                }
                   
                }
                catch
                {
                    return 0;
                }
                            
        }

        public int SavePlayer(int id,int no,string driver)
        {
            
                try
                {
                    int playerId = (from p in _db.Players where p.Driver == driver select p.PlayerId).FirstOrDefault();
                if (playerId>0)
                {
                    return playerId;
                }
                else
                {
                    Player player = new Player();
                    player.TeamId = id;
                    player.No = no;
                    player.Driver = driver;
                    _db.Players.Add(player);
                    _db.SaveChanges();
                    return player.PlayerId;
                }
                   
                }
                catch
                {
                    return 0;
                }
           

        }
        public int SaveResult(int id,string pos,int laps,string time)
        {
            try
                {
                    Result result = new Result();
                    result.PlayerId = id;
                    result.Pos = pos;
                    result.Laps = laps;
                    result.Time = time;
                    _db.Results.Add(result);
                    _db.SaveChanges();
                    return result.ResultId;
                }
            catch
                {
                    return 0;
                }

        }
        [HttpGet]
        public string SaveToDb(string url)
        {
            string message = "";

            try
            {
                CQ html = CQ.CreateFromUrl(url);
                var count = html["tr"].Length;
              
                for (int i = 1; i < count; i++)
                {
                    
                    string pos = (html["tr:nth-child(" + i.ToString() + ")"].Find("td:eq(1)").Text()).ToString();
                    int no = Convert.ToInt32(html["tr:nth-child(" + i.ToString() + ")"].Find("td:eq(2)").Text());
                    string driver = (html["tr:nth-child(" + i.ToString() + ")"].Find("td:eq(3)").Text()).ToString();
                    string teamName = (html["tr:nth-child(" + i.ToString() + ")"].Find("td:eq(4)").Text()).ToString();
                    int laps = Convert.ToInt32(html["tr:nth-child(" + i.ToString() + ")"].Find("td:eq(5)").Text());
                    string time =(html["tr:nth-child(" + i.ToString() + ")"].Find("td:eq(6)").Text()).ToString();
                   
                    //Save teams
                    int teamId = SaveTeam(teamName);

                    if (teamId > 0)
                    {
                       //Save players
                    int playerId = SavePlayer(teamId, no, driver);
                       if (playerId > 0)
                       {
                            //Save results
                           SaveResult(playerId, pos, laps, time);
                       }
                    }
                        message = "Данные успешно сохранены";
                }              
            }
            catch
            {
                message = "Ошибка на сервере";
            }
            return message;
        }
        [HttpGet]
        public string  ParseTable(string url)
        {
            string data = "";
            try
            {
                CQ html = CQ.CreateFromUrl(url);             
                var table = html["table.resultsarchive-table"].Html();
                data = table.ToString();
            }
            catch
            {
                data = "Ошибка соединения с сервером";
            }

            return data;
        }
    }
}