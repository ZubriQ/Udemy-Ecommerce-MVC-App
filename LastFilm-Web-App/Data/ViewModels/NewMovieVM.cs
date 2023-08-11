﻿using LastFilm_Web_App.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace LastFilm_Web_App.Models;

public class NewMovieVM
{
    [Display(Name = "Movie name")]
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Movie description")]
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Price in $")]
    [Required(ErrorMessage = "Price is required")]
    public double Price { get; set; }

    [Display(Name = "Movie poster URL")]
    [Required(ErrorMessage = "Movie poster URL is required")]
    public string ImageURL { get; set; } = string.Empty;

    [Display(Name = "Movie start date")]
    [Required(ErrorMessage = "Start date is required")]
    public DateTime StartDate { get; set; }

    [Display(Name = "Movie end date")]
    [Required(ErrorMessage = "End date is required")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Select a category")]
    [Required(ErrorMessage = "Movie category is required")]
    public MovieCategory MovieCategory { get; set; }

    [Display(Name = "Select a cinema")]
    [Required(ErrorMessage = "Movie cinema is required")]
    public int CinemaId { get; set; }

    [Display(Name = "Select a producer")]
    [Required(ErrorMessage = "Movie producer is required")]
    public int ProducerId { get; set; }

    [Display(Name = "Start actor(s)")]
    [Required(ErrorMessage = "Movie actor(s) is required")]
    public List<int> ActorIds { get; set; } = new List<int>();
}
