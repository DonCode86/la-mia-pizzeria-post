﻿using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace la_mia_pizzeria.Models
{
    public class Pizza
    {
        public Pizza()
        {
        }

        public Pizza(string name, string ingredients, string image, double price)
        {
            Name = name;
            Ingredients = ingredients;
            Image = image;
            Price = price;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(25, ErrorMessage = "Il prezzo non è valido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(200, ErrorMessage = "La lista ingredienti non puo' contenere più di 200 caratteri")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(0,100, ErrorMessage = "Il prezzo non è valido")]
        public double Price { get; set; }

    }
}
