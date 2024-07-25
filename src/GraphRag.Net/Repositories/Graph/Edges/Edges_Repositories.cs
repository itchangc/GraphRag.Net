﻿using GraphRag.Net.Base;

namespace GraphRag.Net.Repositories.Graph.Edges
{
    [ServiceDescription(typeof(IEdges_Repositories), ServiceLifetime.Scoped)]
    public class Edges_Repositories : Repository<Edges>, IEdges_Repositories
    {
    }
}