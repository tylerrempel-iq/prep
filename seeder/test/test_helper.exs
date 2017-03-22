ExUnit.start
#Faker.start

Ecto.Adapters.SQL.Sandbox.mode(IQMetrix.Repo, :manual)

[
  "./lib/",
  "./v1/",
] |> Enum.each(&SpecLoader.load_all_specs_in/1)





