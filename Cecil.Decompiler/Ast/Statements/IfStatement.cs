#region license
//
//	(C) 2005 - 2007 db4objects Inc. http://www.db4o.com
//	(C) 2007 - 2008 Novell, Inc. http://www.novell.com
//	(C) 2007 - 2008 Jb Evain http://evain.net
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
#endregion
// Warning: generated do not edit
using System.Collections.Generic;
using Mono.Cecil.Cil;
using Telerik.JustDecompiler.Ast.Expressions;

namespace Telerik.JustDecompiler.Ast.Statements
{
    public class IfStatement : ConditionStatement
    {
        private BlockStatement then;
        private BlockStatement @else;

        public IfStatement(Expression condition, BlockStatement then, BlockStatement @else)
        : base(condition)
        {
            this.Then = then;
            this.Else = @else;
        }

        public override IEnumerable<ICodeNode> Children
        {
            get
            {
                yield return Condition;
                if (this.Then != null)
                {
                    yield return this.Then;
                }
                if (this.Else != null)
                {
                    yield return this.Else;
                }
            }
        }

        public override Statement Clone()
        {
            BlockStatement clonedThen = null;
            if (then != null)
            {
                clonedThen = then.Clone() as BlockStatement;
            }

            BlockStatement clonedElse = null;
            if (@else != null)
            {
                clonedElse = @else.Clone() as BlockStatement;
            }

            IfStatement result = new IfStatement(Condition.Clone(), clonedThen, clonedElse);
            CopyParentAndLabel(result);
            return result;
        }

        public override Statement CloneStatementOnly()
        {
            BlockStatement clonedThen = then != null ? then.CloneStatementOnly() as BlockStatement : null;
            BlockStatement clonedElse = @else != null ? @else.CloneStatementOnly() as BlockStatement : null;

            IfStatement result = new IfStatement(Condition.CloneExpressionOnly(), clonedThen, clonedElse);
            CopyParentAndLabel(result);
            return result;
        }

        public BlockStatement Then
        {
            get { return this.then; }
            set 
            { 
                this.then = value;
                if (this.then != null)
                {
                    this.then.Parent = this;
                }
            }
        }

        public BlockStatement Else
        {
            get { return this.@else; }
            set
            {
                this.@else = value;
                if (this.@else != null)
                {
                    this.@else.Parent = this;
                }
            }
        }

        public override CodeNodeType CodeNodeType
        {
            get { return CodeNodeType.IfStatement; }
        }
    }
}