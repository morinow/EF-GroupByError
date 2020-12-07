# Sample ASP.NET 5 + EFCore 5 app for reproducing GroupBy-Error
## Test information
ASP.NET Version: 5.0.0

EFCore Version: SqlServer-5.0.0
## Steps to reproduce
### Run ASP.NET app
The database target, specified under config key "ConnectionString" will be built and seeded with sample data.
### Query endpoint
To reproduce the error make a GET request to the endpoint **/groups**.
Parameter: **tags** (true if 'tags' property should be included in query)
If **tags** is set to true (default), the following exception will occur:

```c#
System.InvalidCastException: Unable to cast object of type 'Microsoft.EntityFrameworkCore.Query.SqlExpressions.ColumnExpression' to type 'System.Linq.Expressions.ConstantExpression'.
   at Microsoft.EntityFrameworkCore.Query.RelationalShapedQueryCompilingExpressionVisitor.ShaperProcessingExpressionVisitor.GetProjectionIndex(ProjectionBindingExpression projectionBindingExpression)
   at Microsoft.EntityFrameworkCore.Query.RelationalShapedQueryCompilingExpressionVisitor.ShaperProcessingExpressionVisitor.VisitExtension(Expression extensionExpression)
   at System.Linq.Expressions.Expression.Accept(ExpressionVisitor visitor)
   at System.Linq.Expressions.ExpressionVisitor.Visit(Expression node)
   at System.Dynamic.Utils.ExpressionVisitorUtils.VisitArguments(ExpressionVisitor visitor, IArgumentProvider nodes)
   at System.Linq.Expressions.ExpressionVisitor.VisitArguments(IArgumentProvider nodes)
   at System.Linq.Expressions.ExpressionVisitor.VisitNew(NewExpression node)
   at System.Linq.Expressions.NewExpression.Accept(ExpressionVisitor visitor)
   at System.Linq.Expressions.ExpressionVisitor.Visit(Expression node)
   at Microsoft.EntityFrameworkCore.Query.RelationalShapedQueryCompilingExpressionVisitor.ShaperProcessingExpressionVisitor.ProcessShaper(Expression shaperExpression, RelationalCommandCache& relationalCommandCache, LambdaExpression& relatedDataLoaders)
   at Microsoft.EntityFrameworkCore.Query.RelationalShapedQueryCompilingExpressionVisitor.VisitShapedQuery(ShapedQueryExpression shapedQueryExpression)
   at Microsoft.EntityFrameworkCore.Query.ShapedQueryCompilingExpressionVisitor.VisitExtension(Expression extensionExpression)
   at System.Linq.Expressions.Expression.Accept(ExpressionVisitor visitor)
   at System.Linq.Expressions.ExpressionVisitor.Visit(Expression node)
   at Microsoft.EntityFrameworkCore.Query.QueryCompilationContext.CreateQueryExecutor[TResult](Expression query)
   at Microsoft.EntityFrameworkCore.Storage.Database.CompileQuery[TResult](Expression query, Boolean async)
   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.CompileQueryCore[TResult](IDatabase database, Expression query, IModel model, Boolean async)
   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<>c__DisplayClass12_0`1.<ExecuteAsync>b__0()
   at Microsoft.EntityFrameworkCore.Query.Internal.CompiledQueryCache.GetOrAddQuery[TResult](Object cacheKey, Func`1 compiler)
   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.ExecuteAsync[TResult](Expression query, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryProvider.ExecuteAsync[TResult](Expression expression, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryable`1.GetAsyncEnumerator(CancellationToken cancellationToken)
   at System.Runtime.CompilerServices.ConfiguredCancelableAsyncEnumerable`1.GetAsyncEnumerator()
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at SampleApp.Controllers.SampleController.GroupEntities(Boolean tags) in C:\Development\Work\WAVE\EF-GroupByError\SampleApp\Controllers\SampleController.cs:line 32
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.TaskOfIActionResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--- End of stack trace from previous location ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|19_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)
```