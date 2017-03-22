defmodule IQMetrix.Repo.Migrations.CreatePeople do
  use Ecto.Migration

  def change do
    create table(:people) do
      add :first_name, :string, size: 40
      add :surname, :string, size: 40
      add :age, :integer
      add :birthday, :time
      add :country, :string
      add :profession, :string

      timestamps()
    end

  end
end
