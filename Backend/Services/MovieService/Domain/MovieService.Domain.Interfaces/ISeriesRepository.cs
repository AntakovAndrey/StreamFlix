using MovieService.Domain.Core;

namespace MovieService.Domain.Interfaces;

public interface ISeriesRepository
{
    public IEnumerable <Series> GetSeries();
    public Series GetSeriesById(int id);
    public Series AddSeries(Series product);
    public Series UpdateSeries(Series product);
    public bool DeleteSeries(int id);
}