alias IQMetrix.V1.Models
alias IQMetrix.Repo

defmodule IQMetrix.ModelFactory do
  use ExMachina.Ecto, repo: Repo

  alias FakerElixir, as: Faker
  alias Ecto.UUID, as: UUID


  def professions do
    [
      "Programmer",
      "Cashier",
      "Accountant",
      "Lawyer"
    ]
  end

  def person_factory do
    %Models.Person{
      first_name: Faker.Name.first_name(),
      surname: Faker.Name.last_name(),
      country: Faker.Address.country(),
      age: Faker.Helper.pick(18..120),
      profession: Faker.Helper.pick(professions())
    }
  end
end
