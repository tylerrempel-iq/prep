use Mix.Config

# Do not include metadata nor timestamps in development logs
config :logger, :console, format: "[$level] $message\n"

# Configure your database
config :iqmetrix, IQMetrix.Repo,
  adapter: Ecto.Adapters.MySQL,
  username: "root",
  password: "iqmetrix",
  database: "iq_db",
  hostname: "db",
  pool_size: 10
