﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LamarCompiler.Frames;
using LamarCompiler.Model;
using LamarCompiler.Util;

namespace LamarCompiler
{
    public class FramesCollection : List<Frame>
    {
        /// <summary>
        /// Adds a ReturnFrame to the method that will return a variable of the specified type
        /// </summary>
        /// <param name="returnType"></param>
        /// <returns></returns>
        public ReturnFrame Return(Type returnType)
        {
            var frame = new ReturnFrame(returnType);

            Add(frame);
            return frame;
        }

        /// <summary>
        /// Adds a ReturnFrame for the specified variable
        /// </summary>
        /// <param name="returnVariable"></param>
        /// <returns></returns>
        public ReturnFrame Return(Variable returnVariable)
        {
            var frame = new ReturnFrame(returnVariable);

            Add(frame);
            return frame;
        }

        /// <summary>
        /// Adds a ConstructorFrame<T> to the method frames
        /// </summary>
        /// <param name="constructor"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ConstructorFrame<T> CallConstructor<T>(Expression<Func<T>> constructor)
        {
            var frame = new ConstructorFrame<T>(constructor);
            Add(frame);

            return frame;
        }

        /// <summary>
        /// Add a frame to the end by its type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public FramesCollection Append<T>() where T : Frame, new()
        {
            return Append(new T());
        }

        /// <summary>
        /// Append one or more frames to the end
        /// </summary>
        /// <param name="frames"></param>
        /// <returns></returns>
        public FramesCollection Append(params Frame[] frames)
        {
            this.AddRange(frames);
            return this;
        }

        /// <summary>
        /// Convenience method to add a method call to the GeneratedMethod Frames
        /// collection
        /// </summary>
        /// <param name="expression"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public MethodCall Call<T>(Expression<Action<T>> expression)
        {
            var @call = MethodCall.For(expression);
            Add(@call);

            return @call;
        }

    }
}