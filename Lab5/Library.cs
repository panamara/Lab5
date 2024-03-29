﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;


namespace Lab5;


public class Library
{
    protected List<Book> _catalog;

    public Library()
    {
        _catalog = new List<Book>();
    }

    public IReadOnlyCollection<Book> GetCatalog()
    {
        return _catalog;
    }

    public void AddBook(Book book)
    {
        _catalog.Add(book);
    }

    public IEnumerable<Book> SearchByTitle(string title)
    {
        return _catalog.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Book> SearchByAuthor(string author)
    {
        return _catalog.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Book> SearchByISBN(string isbn)
    {
        return _catalog.Where(b => b.ISBN == isbn);
    }

    public List<string> GetTitles()
    {
        return _catalog.Select(b => b.Title).ToList();
    }

    public List<string> GetAuthors()
    {
        return _catalog.Select(b => b.Author).ToList();
    }

    public List<string> GetDates()
    {
        return _catalog.Select(b => b.PublicationDate.ToString()).ToList();
    }

    public IEnumerable<Book> SearchByTags(IEnumerable<string> tags)
    {
        return _catalog.OrderByDescending(b => tags.Count(k => b.Title.Contains(k, StringComparison.OrdinalIgnoreCase) ||
                                                                   b.Author.Contains(k, StringComparison.OrdinalIgnoreCase) ||
                                                                   b.Genres.Any(g => g.Contains(k, StringComparison.OrdinalIgnoreCase)) ||
                                                                   b.Annotation.Contains(k, StringComparison.OrdinalIgnoreCase)))
                           .ThenBy(b => b.Title);
    }

}

