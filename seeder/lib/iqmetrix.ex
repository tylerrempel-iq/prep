defmodule IQMetrix do
  use Application

  def start(_type, _args) do
    import Supervisor.Spec

    children = [
      supervisor(IQMetrix.Repo, []),
    ]

    opts = [strategy: :one_for_one, name: IQMetrix.Supervisor]
    Supervisor.start_link(children, opts)
  end
end
