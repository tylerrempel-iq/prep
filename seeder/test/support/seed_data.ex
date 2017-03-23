defmodule SeedData do
  def generate_elements(number, builder) when is_atom(builder)  do
    generate_elements(number, fn i -> IQMetrix.ModelFactory.build(builder) end)
  end

  def generate_elements(number, builder) when is_function(builder) do
    items = for element <- 1..number do
      builder.(element)
    end

    results = items |> Enum.map(&IQMetrix.Repo.insert!(&1))

    results
  end
end
