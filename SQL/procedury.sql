create or alter procedure findBooksByTitleOrAuthor
@query varchar(100)
as
select
b.Id as BookId, b.AuthorId, g.Id as GenreId, g.Name as Genre, b.Title,
a.FirstName, a.LastName, a.WritingLanguage
from Books b
join Authors a on a.Id = b.AuthorId
join Genres g on g.Id = b.GenreId
where
b.Title like '%' + @query + '%'
or
a.LastName like '%' + @query + '%'
order by b.Title
;

exec findBooksByTitleOrAuthor 'H';
