﻿using System;
using System.Collections.Generic;

namespace Helper.Structurs
{
	public class PriorityQueue<T>  where T : class
	{
		List<PriorityQueueItem> _binTree = new List<PriorityQueueItem>();
	
		class PriorityQueueItem: IComparable<PriorityQueueItem>
		{
			public T obj;
			int priority;
		
			IComparable<PriorityQueueItem> _comparableImplementation;

			public PriorityQueueItem(T obj, int priority) {
				this.obj = obj;
				this.priority = priority;
			}
			public int CompareTo(PriorityQueueItem other) {

				if (this.priority > other.priority)
					return 1;
				else {
					return -1;
				}
			}
		}

		public void  Push( T obj, int priority) {
		
			_binTree.Add(new PriorityQueueItem( obj, priority));
			int ci = _binTree.Count - 1;
			while (ci  > 0)
			{
				int pi = (ci - 1) / 2;
				if (_binTree[ci].CompareTo(_binTree[pi])  >= 0)
					break;
			
				var tmp = _binTree[ci]; 
				_binTree[ci] = _binTree[pi]; 
				_binTree[pi] = tmp;
				ci = pi;
			}

		}

		public T Pop()
		{
			if (_binTree.Count == 0)
				return null;
		
			// Assumes pq isn't empty
			int li = _binTree.Count - 1;
			var frontItem = _binTree[0];
			_binTree[0] = _binTree[li];
			_binTree.RemoveAt(li);

			--li;
			int pi = 0;
			while (true)
			{
				int ci = pi * 2 + 1;
				if (ci  > li) break;
				int rc = ci + 1;
				if (rc  <= li && _binTree[rc].CompareTo(_binTree[ci])  < 0)
					ci = rc;
				if (_binTree[pi].CompareTo(_binTree[ci])  <= 0) break;
				var tmp = _binTree[pi]; _binTree[pi] = _binTree[ci]; _binTree[ci] = tmp;
				pi = ci;
			}
			return frontItem.obj;
		}

		public void Clear()
		{
			_binTree.Clear();
		}
	}
}
