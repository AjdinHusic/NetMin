import axios from "axios";

const httpClient = axios.create({
  baseURL: "https://localhost:7087",
});

export default httpClient;
