alias IQMetrix.V1.Models
alias IQMetrix.Repo

defmodule Models.Person do
  use IQMetrix.Web, :model

  schema "people" do
    field :first_name, :string
    field :surname, :string
    field :age, :integer
    field :birthday, :time
    field :country, :string
    field :profession, :string

    timestamps()
  end
end
