/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeActions/TradeAction.cs#1 $
      $DateTime: 2007/04/11 12:03:59 $
      $Change: 3195 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ring1;
using Starcounter.Data;

namespace Ring2
{
    /// <summary>
    /// An action that can be processed on a Something, e.g. Approve on a Order.
    /// </summary>
    public class TradeAction : Something
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Something.Kind"/>
        public new class Kind : Something.Kind
        {
            public TradeAction ActionPerformed(Somebody processor, Something processedObject)
            {
                TradeAction action = (TradeAction) New();
                action.Processor = processor;
                action.ProcessedObject = processedObject;
                action.When = DateTime.Now;

                return action;
            }

            /// <summary>
            /// Returns the first action of the given kind, between the processor and the processedObject.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processor"></param>
            /// <param name="processedObject"></param>
            /// <returns></returns>
            public TradeAction GetFirst(TradeAction.Kind kind, Somebody processor, Something processedObject)
            {
                ICollection<Persistent> result = kind.FindMany("Processor = {0} AND ProcessedObject = {1}", new Object[] { processor, processedObject });
                TradeAction first = null;

                foreach (TradeAction action in result)
                {
                    if (first == null || action.When < first.When)
                    {
                        first = action;
                    }
                }

                return first;
            }

            /// <summary>
            /// Returns the first action of the given kind, between the processor and the processedObjects.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processor"></param>
            /// <param name="processedObjects"></param>
            /// <returns></returns>
            public TradeAction GetFirst(TradeAction.Kind kind, Somebody processor, ICollection processedObjects)
            {
                TradeAction first = null;

                foreach (Something processedObject in processedObjects)
                {
                    TradeAction action = GetFirst(kind, processor, processedObject);

                    if (first == null || action.When < first.When)
                    {
                        first = action;
                    }
                }

                return first;
            }

            /// <summary>
            /// Returns the first action of the given kind, for the given processedObject.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processedObject"></param>
            /// <returns></returns>
            public TradeAction GetFirstForObject(TradeAction.Kind kind, Something processedObject)
            {
                ICollection<Persistent> result = kind.FindMany("ProcessedObject = {0}", new Object[] { processedObject });
                TradeAction first = null;

                foreach (TradeAction action in result)
                {
                    if (first == null || action.When < first.When)
                    {
                        first = action;
                    }
                }

                return first;
            }

            /// <summary>
            /// Returns the first action of the given kind, for the processedObjects.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processedObjects"></param>
            /// <returns></returns>
            public TradeAction GetFirstForObjects(TradeAction.Kind kind, ICollection processedObjects)
            {
                TradeAction first = null;

                foreach (Something processedObject in processedObjects)
                {
                    TradeAction action = GetFirstForObject(kind, processedObject);

                    if (first == null || action.When < first.When)
                    {
                        first = action;
                    }
                }

                return first;
            }

            /// <summary>
            /// Returns the first action of the given kind, for the given processor.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processor"></param>
            /// <returns></returns>
            public TradeAction GetFirstForProcessor(TradeAction.Kind kind, Somebody processor)
            {
                ICollection<Persistent> result = kind.FindMany("Processor = {0}", new Object[] { processor });
                TradeAction first = null;

                foreach (TradeAction action in result)
                {
                    if (first == null || action.When < first.When)
                    {
                        first = action;
                    }
                }

                return first;
            }

            /// <summary>
            /// Returns the first action of the given kind, for the given processors.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processors"></param>
            /// <returns></returns>
            public TradeAction GetFirstForProcessors(TradeAction.Kind kind, ICollection processors)
            {
                TradeAction first = null;

                foreach (Somebody processor in processors)
                {
                    TradeAction action = GetFirstForProcessor(kind, processor);

                    if (first == null || action.When < first.When)
                    {
                        first = action;
                    }
                }

                return first;
            }

            #region Get-methods

            /// <summary>
            /// Returns the processor that was the first one to perform the TradeAction for the given object.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processedObject"></param>
            /// <returns></returns>
            public Somebody GetFirstProcessor(TradeAction.Kind kind, Something processedObject)
            {
                TradeAction first = GetFirstForObject(kind, processedObject);
                return (first != null) ? first.Processor : null;
            }

            /// <summary>
            /// Returns the processor that was the first one to perform the TradeAction for the given objects.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processedObjects"></param>
            /// <returns></returns>
            public Somebody GetFirstProcessor(TradeAction.Kind kind, ICollection processedObjects)
            {
                TradeAction first = GetFirstForObjects(kind, processedObjects);
                return (first != null) ? first.Processor : null;
            }

            /// <summary>
            /// Returns the processedObject that was the first one on a TradeAction for the given processor.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processor"></param>
            /// <returns></returns>
            public Something GetFirstProcessedObject(TradeAction.Kind kind, Somebody processor)
            {
                TradeAction first = GetFirstForProcessor(kind, processor);
                return (first != null) ? first.ProcessedObject : null;
            }

            /// <summary>
            /// Returns the processedObject that was the first one on a TradeAction for the given processors.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processors"></param>
            /// <returns></returns>
            public Something GetFirstProcessedObject(TradeAction.Kind kind, ICollection processors)
            {
                TradeAction first = GetFirstForObjects(kind, processors);
                return (first != null) ? first.ProcessedObject : null;
            }

            /// <summary>
            /// Returns the latest action of the given kind, between the processor and the processedObject.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processor"></param>
            /// <param name="processedObject"></param>
            /// <returns></returns>
            public TradeAction GetLatest(TradeAction.Kind kind, Somebody processor, Something processedObject)
            {
                ICollection<Persistent> result = kind.FindMany("Processor = {0} AND ProcessedObject = {1}", new Object[] { processor, processedObject });
                TradeAction latest = null;

                foreach (TradeAction action in result)
                {
                    if (latest == null || action.When > latest.When)
                    {
                        latest = action;
                    }
                }

                return latest;
            }

            /// <summary>
            /// Returns the latest action of the given kind, between the processor and the processedObjects.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processor"></param>
            /// <param name="processedObjects"></param>
            /// <returns></returns>
            public TradeAction GetLatest(TradeAction.Kind kind, Somebody processor, ICollection processedObjects)
            {
                TradeAction latest = null;

                foreach (Something processedObject in processedObjects)
                {
                    TradeAction action = GetLatest(kind, processor, processedObject);

                    if (latest == null || action.When > latest.When)
                    {
                        latest = action;
                    }
                }

                return latest;
            }

            /// <summary>
            /// Returns the latest action of the given kind, for the given processedObject.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processedObject"></param>
            /// <returns></returns>
            public TradeAction GetLatestForObject(TradeAction.Kind kind, Something processedObject)
            {
                ICollection<Persistent> result = kind.FindMany("ProcessedObject = {0}", new Object[] { processedObject });
                TradeAction latest = null;

                foreach (TradeAction action in result)
                {
                    if (latest == null || action.When > latest.When)
                    {
                        latest = action;
                    }
                }

                return latest;
            }

            /// <summary>
            /// Returns the latest action of the given kind, for the processedObjects.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processedObjects"></param>
            /// <returns></returns>
            public TradeAction GetLatestForObjects(TradeAction.Kind kind, ICollection processedObjects)
            {
                TradeAction latest = null;

                foreach (Something processedObject in processedObjects)
                {
                    TradeAction action = GetLatestForObject(kind, processedObject);

                    if (latest == null || action.When > latest.When)
                    {
                        latest = action;
                    }
                }

                return latest;
            }

            /// <summary>
            /// Returns the latest action of the given kind, for the given processor.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processor"></param>
            /// <returns></returns>
            public TradeAction GetLatestForProcessor(TradeAction.Kind kind, Somebody processor)
            {
                ICollection<Persistent> result = kind.FindMany("Processor = {0}", new Object[] { processor });
                TradeAction latest = null;

                foreach (TradeAction action in result)
                {
                    if (latest == null || action.When > latest.When)
                    {
                        latest = action;
                    }
                }

                return latest;
            }

            /// <summary>
            /// Returns the latest action of the given kind, for the given processors.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processors"></param>
            /// <returns></returns>
            public TradeAction GetLatestForProcessors(TradeAction.Kind kind, ICollection processors)
            {
                TradeAction latestForProcessors = null;

                foreach (Somebody processor in processors)
                {
                    TradeAction action = GetFirstForProcessor(kind, processor);

                    if (latestForProcessors == null || action.When > latestForProcessors.When)
                    {
                        latestForProcessors = action;
                    }
                }

                return latestForProcessors;
            }

            /// <summary>
            /// Returns the processor that was the last one to perform the TradeAction for the given object.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processedObject"></param>
            /// <returns></returns>
            public Somebody GetLatestProcessor(TradeAction.Kind kind, Something processedObject)
            {
                TradeAction latest = GetLatestForObject(kind, processedObject);
                return (latest != null) ? latest.Processor : null;
            }

            /// <summary>
            /// Returns the processor that was the last one to perform the TradeAction for the given objects.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processedObjects"></param>
            /// <returns></returns>
            public Somebody GetLatestProcessor(TradeAction.Kind kind, ICollection processedObjects)
            {
                TradeAction latest = GetLatestForObjects(kind, processedObjects);
                return (latest != null) ? latest.Processor : null;
            }

            /// <summary>
            /// Returns the processedObject that was the latest one on a TradeAction for the given processor.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processor"></param>
            /// <returns></returns>
            public Something GetLatestProcessedObject(TradeAction.Kind kind, Somebody processor)
            {
                TradeAction latest = GetLatestForProcessor(kind, processor);
                return (latest != null) ? latest.ProcessedObject : null;
            }

            /// <summary>
            /// Returns the processedObject that was the latest one on a TradeAction for the given processors.
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="processors"></param>
            /// <returns></returns>
            public Something GetLatestProcessedObject(TradeAction.Kind kind, ICollection processors)
            {
                TradeAction latest = GetLatestForObjects(kind, processors);
                return (latest != null) ? latest.ProcessedObject : null;
            }
            #endregion
        }
        #endregion       
        
        public Somebody Processor;

        public Something ProcessedObject;

        public DateTime When;
    }
}
