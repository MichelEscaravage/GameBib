﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameBib.Data.Classes;
using GameBib.Data.Lists;


namespace GameBib
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<GameGenre> GameGenre { get; set; } 
        public DbSet<User> User {  get; set; }  
        public DbSet<UserGames> UserGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "port=3306;" +
                "user=root;" +
                "password=;" +
                "database=csd_gamebib",
                ServerVersion.Parse("10.4.17-mariadb"));
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameGenre>().HasKey(gg => new {gg.GameId, gg.GenreId});
            modelBuilder.Entity<GameGenre>().HasOne(gg => gg.Game).WithMany(g => g.GameGenres).HasForeignKey(gg => gg.GameId);  
            modelBuilder.Entity<GameGenre>().HasOne(gg => gg.Genre).WithMany(g => g.GameGenres).HasForeignKey(gg => gg.GenreId);  

            modelBuilder.Entity<UserGames>().HasKey(ug => new {ug.UserId, ug.GameId});
            modelBuilder.Entity<UserGames>().HasOne(gg => gg.User).WithMany(u => u.UserGames).HasForeignKey(gg => gg.UserId);
            modelBuilder.Entity<UserGames>().HasOne(gg => gg.Game).WithMany(g => g.UserGames).HasForeignKey(gg => gg.GameId);

            GameList gamesList = new GameList();
            GenreList genresList = new GenreList();
            GamesGenresLists gamesGenresLists = new GamesGenresLists();
            UserGamesList userGamesList = new UserGamesList();
            UserList userList = new UserList();
            
            List<Game> games = gamesList.GetGameList();
            List<Genre> genres = genresList.GetGenreList();
            List<GameGenre> gameGenres = gamesGenresLists.GetGameGenres();
            List<UserGames> userGames = userGamesList.GetUserGames();
            List<User> users = userList.GetUserList();

            modelBuilder.Entity<User>().HasData(users.ToArray());
            modelBuilder.Entity<Game>().HasData(games.ToArray());
            modelBuilder.Entity<Genre>().HasData(genres.ToArray());
            modelBuilder.Entity<GameGenre>().HasData(gameGenres.ToArray());
            modelBuilder.Entity<UserGames>().HasData(userGames.ToArray());
        }
    }
}
