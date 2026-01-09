import { useState } from "react";

function App() {
  const [city, setCity] = useState("");
  const [weather, setWeather] = useState(null);
  const [error, setError] = useState("");
  const API_KEY = import.meta.env.VITE_API_KEY;
  const fetchWeather = async () => {
    setError("");
    setWeather(null);

    try {
      const response = await fetch(
        `http://localhost:5075/api/weather?city=${city}`,
        {
          method: "GET",
          headers: {
            "X-API-Key": API_KEY,
            "Content-Type": "application/json"
          }
        }
      );

      if (!response.ok) {
        throw new Error(`Erro ${response.status}`);
      }

      const data = await response.json();
      setWeather(data);
    } catch (err) {
      console.error(err);
      setError("Não foi possível buscar o clima");
    }
  };

  return (
    <div style={{ padding: "2rem", fontFamily: "Arial" }}>
      <h1>Clima</h1>

      <input
        type="text"
        placeholder="Digite a cidade"
        value={city}
        onChange={(e) => setCity(e.target.value)}
      />

      <button onClick={fetchWeather} style={{ marginLeft: "1rem" }}>
        Buscar
      </button>

      {error && <p style={{ color: "red" }}>{error}</p>}

      {weather && (
  <div style={{ marginTop: "1rem" }}>
    <p><strong>Cidade:</strong> {weather.city}</p>
    <p><strong>Temperatura:</strong> {weather.temperatureC} °C</p>
    <p><strong>Condição:</strong> {weather.condition}</p>
    <p><strong>Umidade:</strong> {weather.humidity}%</p>
  </div>
)}

    </div>
  );
}

export default App;
