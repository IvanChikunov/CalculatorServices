export const server =
  process.env.NODE_ENV == "development"
    ? "https://localhost:44302/"
    : "http://localhost:8080/";
