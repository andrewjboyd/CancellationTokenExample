import React, { useEffect, useState } from 'react';

export function FetchData() {
  const [forecasts, setForecasts] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const controller = new AbortController();
  
    async function populateWeatherData() {
      const response = await fetch('https://localhost:7086/weatherforecast', { signal: controller.signal });
      const data = await response.json();
      setForecasts(data);
      setLoading(false);
    }

    populateWeatherData();

    return () => {
      controller.abort();
    }
  }, []);

  function renderForecastsTable() {
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map((forecast) => (
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  return (
    <div>
      <h1 id="tableLabel">Weather forecast</h1>
      <p>This component demonstrates fetching data from the server.</p>
      {loading ? <p><em>Loading...</em></p> : renderForecastsTable()}
    </div>
  );
}
